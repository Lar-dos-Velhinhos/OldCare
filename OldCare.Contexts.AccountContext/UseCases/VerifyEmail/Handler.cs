using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.VerifyEmail.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using IRepository = OldCare.Contexts.AccountContext.UseCases.VerifyEmail.Contracts.IRepository;
using ReCaptchaService = OldCare.Services.Google.ReCaptcha.Contracts.IService;

namespace OldCare.Contexts.AccountContext.UseCases.VerifyEmail;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    #region Private Properties

    private readonly SharedContext.Services.Log.Contracts.IService _logService;
    private readonly ReCaptchaService _reCaptchaService;
    private readonly IRepository _repository;
    private readonly IService _service;

    #endregion

    #region Constructors

    public Handler(
        SharedContext.Services.Log.Contracts.IService logService,
        ReCaptchaService reCaptchaService,
        IRepository repository,
        IService service)
    {
        _reCaptchaService = reCaptchaService;
        _repository = repository;
        _service = service;
        _logService = logService;
    }

    #endregion

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Verifica o ReCaptcha

        try
        {
            var reCaptchaResponse = await _reCaptchaService.VerifyAsync(request.GoogleReCaptchaResponse);
            if (reCaptchaResponse is { Success: false })
                return new BaseResponse<ResponseData>("ReCaptcha inválido", "ReCaptcha");
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível validar o ReCaptcha", "ReCaptcha");
        }

        #endregion

        #region 02. Extrai os dados do Hash

        string email;
        string verificationCode;

        try
        {
            var data = request.ExtractDataFromHash();
            email = data?[0] ?? string.Empty;
            verificationCode = data?[1] ?? string.Empty;
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível validar o código de ativação", "VerificationCode");
        }

        if (email != request.Email)
            return new BaseResponse<ResponseData>("Código de verificação inválido", "VerificationCode");

        if (verificationCode != request.VerificationCode)
            return new BaseResponse<ResponseData>("Código de ativação verificação", "VerificationCode");

        #endregion

        #region 03. Recupera o aluno por email

        User? user;

        try
        {
            user = await _repository.GetUserByUsernameAsync(request.Email);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Conta não encontrada", "Student", 404);
        }

        #endregion

        #region 04. Verifica se o aluno existe

        if (user is null)
            return new BaseResponse<ResponseData>("Conta não encontrada", "Student", 404);

        #endregion

        #region 05. Verifica se a conta está no BlackList

        var accountIsBlackListed = await _repository.CheckAccountIsBlackListedAsync(request.Email);
        if (accountIsBlackListed)
            return new BaseResponse<ResponseData>("Esta conta está bloqueada", "Email");

        #endregion

        #region 06. Verificar existência, expiração e validação do emailVerificationCode

        try
        {
            user.VerifyEmail(request.VerificationCode);
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex);
        }

        #endregion

        #region 07. Persiste os dados

        try
        {
            await _repository.SaveAsync(user);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ex.Message);
            return new BaseResponse<ResponseData>("Não foi possível verificar sua conta.");
        }

        #endregion

        #region 08. Envia E-mail de ativação da conta

        try
        {
            await _service.SendAccountVerifiedEmailAsync(user);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ex.Message);
        }

        #endregion

        #region 08. Retornar mensagem de sucesso

        return new BaseResponse<ResponseData>(new ResponseData("Email verificado com sucesso."));

        #endregion
    }
}
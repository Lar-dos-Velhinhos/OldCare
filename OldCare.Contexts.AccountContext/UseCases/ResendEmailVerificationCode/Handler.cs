using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.ResendEmailVerificationCode.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using IService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;
using ReCaptchaService = OldCare.Services.Google.ReCaptcha.Contracts.IService;

namespace OldCare.Contexts.AccountContext.UseCases.ResendEmailVerificationCode;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    #region Private Properties

    private readonly ReCaptchaService _reCaptchaService;
    private readonly IRepository _repository;
    private readonly Contracts.IService _service;
    private readonly IService _logService;

    #endregion

    #region Constructors

    public Handler(
        ReCaptchaService reCaptchaService,
        IRepository repository,
        Contracts.IService service,
        IService logService)
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
            if (reCaptchaResponse is null || reCaptchaResponse.Success == false)
                return new BaseResponse<ResponseData>("ReCaptcha inválido", "ReCaptcha");
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível validar o ReCaptcha", "ReCaptcha");
        }

        #endregion

        #region 02. Recuperar aluno por e-mail

        User? user;

        try
        {
            user = await _repository.GetUserByUsernameAsync(request.Email);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível recuperar os dados da sua conta!");
        }

        #endregion

        #region 03. Verificar se o aluno existe

        if (user is null)
            return new BaseResponse<ResponseData>("Conta não encontrada", "Student", 404);

        #endregion

        #region 04. Verificar se a conta está ativa

        if (!user.CanLogIn)
            return new BaseResponse<ResponseData>("Esta conta está desativada", "23ca82da");

        #endregion

        #region 04. Verificar se está na blacklist

        var accountIsBlackListed = await _repository.CheckAccountIsBlackListedAsync(request.Email);
        if (accountIsBlackListed)
            return new BaseResponse<ResponseData>("Esta conta está bloqueada", "Email");

        #endregion

        #region 05. Gerar novo código de verificação

        user.GenerateEmailVerificationCode();

        #endregion

        #region 05. Persiste dados

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

        #region 06. Envia o novo código por e-mail

        try
        {
            await _service.ResendEmailVerificationCodeAsync(user);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ex.Message);
            return new BaseResponse<ResponseData>("Não foi possível enviar o código de verificação");
        }

        #endregion

        #region 07. Retorna mensagem de sucesso

        return new BaseResponse<ResponseData>(new ResponseData("Novo código de verificação enviado com sucesso."));

        #endregion
    }
}
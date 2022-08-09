using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.RequestPasswordResetCode.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using ReCaptchaService = OldCare.Services.Google.ReCaptcha.Contracts.IService;

namespace OldCare.Contexts.AccountContext.UseCases.RequestPasswordResetCode;

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

        #region 02. Verifica se a conta está no BlackList

        var accountIsBlackListed = await _repository.CheckAccountIsBlackListedAsync(request.Email);
        if (accountIsBlackListed)
            return new BaseResponse<ResponseData>("Esta conta está bloqueada", "Email");

        #endregion

        #region 03. Recuperar aluno por email

        User? user;

        try
        {
            user = await _repository.GetUserByUsernameAsync(request.Email);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível recuperar os dados da sua conta", "Student");
        }

        #endregion

        #region 04. Verifica se o aluno existe

        if (user is null)
            return new BaseResponse<ResponseData>("Conta não encontrada", "Student", 404);

        #endregion

        #region 05. Enviar e-mail com código de verificação

        try
        {
            await _service.SendPasswordVerificationCodeAsync(user);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Ocorreu um erro ao enviar o e-mail de verificação.");
        }

        #endregion

        #region 06. Retornar mensagem de sucesso

        return new BaseResponse<ResponseData>(
            new ResponseData($"Um e-mail foi enviado para {request.Email} com um link para redefinição da senha."));

        #endregion
    }
}
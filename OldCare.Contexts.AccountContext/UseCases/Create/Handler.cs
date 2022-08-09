using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.Create.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using OldCare.Contexts.SharedContext.ValueObjects;
using MediatR;
using ReCaptchaService = OldCare.Services.Google.ReCaptcha.Contracts.IService;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;

namespace OldCare.Contexts.AccountContext.UseCases.Create;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    #region Private Properties

    private readonly LogService _logService;
    private readonly ReCaptchaService _reCaptchaService;
    private readonly IRepository _repository;
    private readonly IService _service;

    #endregion

    #region Constructors

    public Handler(
        LogService logService,
        ReCaptchaService reCaptchaService,
        IRepository repository,
        IService service
    )
    {
        _logService = logService;
        _reCaptchaService = reCaptchaService;
        _repository = repository;
        _service = service;
    }

    #endregion

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Verify recaptcha

        try
        {
            var reCaptchaResponse = await _reCaptchaService.VerifyAsync(request.GoogleReCaptchaResponse);
            if (reCaptchaResponse is { Success: false })
                return new BaseResponse<ResponseData>("ReCaptcha inválido", "ReCaptcha");
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex);
        }

        #endregion

        #region 02. Create entity

        User user;
        try
        {
            user = new User(
                request.Email,
                request.Password);
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex);
        }

        #endregion

        #region 03. Check if account is blacklisted

        var accountIsBlackListed = await _repository.CheckAccountIsBlackListedAsync(request.Email);
        if (accountIsBlackListed)
        {
            await _logService.LogAsync($"🔒️{request.Email} - Tentativa de login com conta bloqueada.");
            return new BaseResponse<ResponseData>("Esta conta está bloqueada", "Email");
        }

        #endregion

        #region 04. Verify if e-mail is already in use

        var accountExists = await _repository.CheckAccountExistsAsync(request.Email);
        if (accountExists)
            return new BaseResponse<ResponseData>("Este E-mail já está em uso", "Email");

        #endregion

        #region 05. Persist data

        try
        {
            await _repository.CreateAsync(user);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ex.Message);
            return new BaseResponse<ResponseData>("⚠️ Não foi possível realizar seu cadastro!", "94BF0DA3");
        }

        #endregion

        #region 07. Send account verification e-mail

        try
        {
            await _service.SendEmailVerificationCodeAsync(user, request.ReturnUrl);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ex.Message);
        }

        #endregion

        #region 08. Return success response

        return new BaseResponse<ResponseData>(new ResponseData("Bem vindo(a) ao OldCare!"), 201);

        #endregion
    }
}
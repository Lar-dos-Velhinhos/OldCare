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
        #region 01. Verifica o ReCaptcha

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

        #region 02. Gera a agregado raiz

        Student student;
        try
        {
            var utm = new Utm(request.UtmSource, request.UtmCampaign, request.UtmContent, request.UtmMedium);
            student = new Student(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                null,
                null,
                utm);
            student.AddActivity("Criação da conta");
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex);
        }

        #endregion

        #region 03. Verifica se a conta está no BlackList

        var accountIsBlackListed = await _repository.CheckAccountIsBlackListedAsync(request.Email);
        if (accountIsBlackListed)
        {
            await _logService.LogAsync($"🔒️{request.Email} - Tentativa de login com conta bloqueada.");
            return new BaseResponse<ResponseData>("Esta conta está bloqueada", "Email");
        }

        #endregion

        #region 04. Verifica se o E-mail já está em uso

        var accountExists = await _repository.CheckAccountExistsAsync(request.Email);
        if (accountExists)
            return new BaseResponse<ResponseData>("Este E-mail já está em uso", "Email");

        #endregion

        var tags = await _repository.GetTagsAsync();
        student.AddDefaultTags(tags.ToList(), request.SubscribeToNewsletter);

        #region 05. Persiste os dados no banco

        try
        {
            await _repository.CreateAsync(student);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ex.Message);
            return new BaseResponse<ResponseData>("⚠️ Não foi possível realizar seu cadastro!", "94BF0DA3");
        }

        #endregion

        #region 07. Envia E-mail de ativação da conta

        try
        {
            await _service.SendEmailVerificationCodeAsync(student, request.ReturnUrl);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ex.Message);
        }

        #endregion

        #region 08. Retorna uma resposta de sucesso

        return new BaseResponse<ResponseData>(new ResponseData("Bem vindo(a) ao balta.io!"), 201);

        #endregion
    }
}
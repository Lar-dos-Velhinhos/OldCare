using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.ChangeEmail.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using IService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;
using ReCaptchaService = OldCare.Services.Google.ReCaptcha.Contracts.IService;

namespace OldCare.Contexts.AccountContext.UseCases.ChangeEmail;

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
        
        if (request.NewEmail == request.OldEmail)
            return new BaseResponse<ResponseData>($"Seu E-mail já é {request.NewEmail}!", "Email", 400);        
        
        #region 02. Verifica se a conta está no BlackList

        var accountIsBlackListed = await _repository.CheckAccountIsBlackListedAsync(request.NewEmail);
        if (accountIsBlackListed)
            return new BaseResponse<ResponseData>($"O E-mail {request.NewEmail} está bloqueado.", "Email");

        #endregion

        #region 03. Recuperar aluno por email

        User? user;

        try
        {
            user = await _repository.GetUserByUsernameAsync(request.OldEmail);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Conta não encontrada", "e96718e4", 404);
        }

        #endregion

        #region 04. Verifica se o aluno existe

        if (user is null)
            return new BaseResponse<ResponseData>("Conta não encontrada", "d2836988", 404);

        #endregion
        
        try
        {
            user?.Authenticate(request.Password);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Senha inválida", "8ff53c6f", 404);
        }

        #region 05. Verificar se o e-mail novo está em uso

        var newAccountExists = await _repository.CheckAccountExistAsync(request.NewEmail);
        if (newAccountExists)
            return new BaseResponse<ResponseData>(new ResponseData("Este e-mail está em uso."), 400);

        #endregion

        #region 06. Trocar e-mail antigo

        try
        {
            user?.ChangeUsername(request.NewEmail);
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex);
        }

        #endregion

        #region 07. Persiste dados

        try
        {
            await _repository.SaveAsync(user);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível alterar o E-mail.", "Email");
        }

        #endregion

        #region 08. Envia o novo código por e-mail

        try
        {
            await _service.SendAccountVerificationEmailAsync(user);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ex.Message);
        }

        #endregion

        #region 09. Retorna mensagem de sucesso

        return new BaseResponse<ResponseData>(
            new ResponseData("Um código de verificação foi enviado para o novo e-mail."));

        #endregion
    }
}
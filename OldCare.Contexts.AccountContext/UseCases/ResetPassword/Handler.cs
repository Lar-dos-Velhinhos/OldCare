using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.ResetPassword.Contracts;
using OldCare.Contexts.SharedContext.Extensions;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using ReCaptchaService = OldCare.Services.Google.ReCaptcha.Contracts.IService;

namespace OldCare.Contexts.AccountContext.UseCases.ResetPassword;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    #region Private Properties

    private readonly IRepository _repository;
    private readonly ReCaptchaService _reCaptchaService;

    #endregion

    #region Constructors

    public Handler(
        IRepository repository,
        ReCaptchaService reCaptchaService)
    {
        _repository = repository;
        _reCaptchaService = reCaptchaService;
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

        #region 01. Recuperar aluno por email

        Student? student;

        try
        {
            student = await _repository.GetStudentByEmailAsync(request.Email);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Conta não encontrada", "Student", 404);
        }

        #endregion

        #region 02. Verifica se o aluno existe

        if (student is null)
            return new BaseResponse<ResponseData>("Conta não encontrada", "Student", 404);

        #endregion

        #region 03. Verificar o código

        var base64Code = $"{student.Id}:{student.Email}".ToBase64();
        if (request.VerificationCode != base64Code)
            return new BaseResponse<ResponseData>("Código de verificação inválido.");

        try
        {
            student.ResetPassword(request.Password, request.VerificationCode);
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex);
        }

        #endregion

        #region 04. Persistir os dados

        try
        {
            await _repository.SaveAsync(student);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível alterar a sua senha.");
        }

        #endregion

        #region 05. Retornar mensagem de sucesso

        return new BaseResponse<ResponseData>(new ResponseData($"Senha alterada com sucesso!"));

        #endregion
    }
}
using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.ChangePassword.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;

namespace OldCare.Contexts.AccountContext.UseCases.ChangePassword;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    #region Private Properties

    private readonly IRepository _repository;
    private readonly LogService _logService;

    #endregion

    #region Constructors

    public Handler(
        IRepository repository,
        LogService logService)
    {
        _repository = repository;
        _logService = logService;
    }

    #endregion

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Verificar novas senhas digitadas

        if (!request.NewPassword.Equals(request.NewPasswordConfirmation))
            return new BaseResponse<ResponseData>("As novas senhas não conferem.");

        #endregion

        #region 02. Recuperar aluno por email

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

        #region 03. Verifica se o aluno existe

        if (student is null)
            return new BaseResponse<ResponseData>("Conta não encontrada", "Student", 404);

        #endregion

        #region 04. Verificar se a senha digitada corresponde a senha salva

        try
        {
            student.Authenticate(request.OldPassword);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Senha atual inválida", "73d2a6e2");
        }

        #endregion

        #region 05. Trocar a senha

        try
        {
            student.ChangePassword(request.NewPassword);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível trocar a senha.");
        }

        #endregion

        #region 06. Persiste dados

        try
        {
            await _repository.SaveAsync(student);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível trocar a senha.");
        }

        #endregion

        #region 08. Retorna mensagem de sucesso

        return new BaseResponse<ResponseData>(new ResponseData("Senha alterada com sucesso."));

        #endregion
    }
}
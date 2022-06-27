using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.Edit.Contracts;
using OldCare.Contexts.SharedContext.Extensions;
using OldCare.Contexts.SharedContext.Services.Log.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using OldCare.Contexts.SharedContext.ValueObjects;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.Edit;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    #region Private Properties

    private readonly IRepository _repository;
    private readonly IService _logService;

    #endregion

    #region Constructors

    public Handler(
        IRepository repository,
        IService logService)
    {
        _repository = repository;
        _logService = logService;
    }

    #endregion

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Validar CPF do aluno
        
        // Document cpf = request.Document;
        //
        // if (!cpf.IsCpf())
        //     return new BaseResponse<ResponseData>("Cpf inválido", "b95ad2df");

        #endregion
        
        #region 02. Recuperar aluno por email

        User? user;

        try
        {
            user = await _repository.GetUserByUsernameAsync(request.Email);
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex);
        }

        #endregion

        #region 03. Verificar se o aluno existe

        if (user is null)
            return new BaseResponse<ResponseData>("Conta não encontrada", "Student", 404);

        #endregion

        #region 04. Atribuir valores da requisição ao aluno

        try
        {
            user.Person.ChangeInformation(
                request.FirstName,
                request.LastName,
                request.BirthDate,
                "");
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível salvar as alterações!", "7b2d523d");
        }
        
        #endregion

        #region 05. Atribuir telefone ao aluno

        try
        {
            if (request.Phone != null)
                user.Person.ChangePhone(request.Phone.ToNumbersOnly());
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível salvar as alterações!", "38803002");
        }

        #endregion

        #region 06. Persistir os dados no banco

        try
        {
            await _repository.SaveAsync(user);
        }
        catch
        {
            await _logService.LogAsync(
                "⚠ Não foi possível realizar as alterações de informação do aluno ({request.Email}).");
            return new BaseResponse<ResponseData>("Não foi possível salvar as alterações!", "ddb9f50d");
        }

        #endregion

        #region 05. Retornar mensagem de sucesso

        return new BaseResponse<ResponseData>(new ResponseData("Alterações salvas com sucesso."));

        #endregion
    }
}
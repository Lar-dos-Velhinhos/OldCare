using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.Delete.Contracts;
using OldCare.Contexts.SharedContext.Services.Log.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.Delete;

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
        #region 01. Confirmar se o aluno leu o aviso

        if (!request.ConfirmDelete)
            return new BaseResponse<ResponseData>("É necessário confirmar que leu o aviso");

        #endregion
        
        #region 02. Recuperar aluno por email

        Student? student;

        try
        {
            student = await _repository.GetStudentByEmailAsync(request.Email);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível continuar com a solicitação.", "a297cb67");
        }

        #endregion

        #region 03. Verificar se o aluno existe

        if (student is null)
        {
            return new BaseResponse<ResponseData>("Não foi possível continuar com a solicitação.", "e1593f13", 404);
        }

        #endregion
        
        #region 04. Autenticar o aluno

        try
        {
            student.Authenticate(request.Password);
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex);
        }
        
        #endregion

        #region 05. Remover as informações do aluno

        try
        {
            student.EraseData(request.FeedbackOption, request.FeedbackMessage);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível excluir as informações do aluno", "d07f1a54", 500);
        }

        #endregion

        #region 06. Persistir os dados

        try
        {
            await _repository.SaveAsync(student);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Ocorreu um erro ao remover as informações do aluno.", "d863c126");
        }

        #endregion

        #region 07. Retornar mensagem de sucesso
        
        return new BaseResponse<ResponseData>("Dados excluídos com sucesso.", student.Email, 200);

        #endregion
    }
}
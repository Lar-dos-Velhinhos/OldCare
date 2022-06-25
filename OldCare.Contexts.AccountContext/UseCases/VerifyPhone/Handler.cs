using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.SharedContext.Services.Log.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using IRepository = OldCare.Contexts.AccountContext.UseCases.VerifyPhone.Contracts.IRepository;

namespace OldCare.Contexts.AccountContext.UseCases.VerifyPhone;

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
        #region 01. Recuperar aluno por email

        Student? student;

        try
        {
            student = await _repository.GetStudentByEmailAsync(request.Email);
            
            if (student is not null)
                request.PhoneNumber = student.Phone;
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex);
        }

        #endregion

        #region 02. Verifica se o aluno existe

        if (student is null)
            return new BaseResponse<ResponseData>("Conta não encontrada", "Student", 404);

        #endregion

        #region 03. Verificar existência, expiração e validação do PhoneVerificationCode

        try
        {
            student.VerifyPhone(request.VerificationCode);
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex.Message, "dd4194c9", 401);
        }

        #endregion

        #region 04. Persiste os dados

        try
        {
            await _repository.SaveAsync(student);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ex.Message);
            return new BaseResponse<ResponseData>("Não foi possível verificar seu telefone.");
        }

        #endregion

        #region 05. Retornar mensagem de sucesso

        return new BaseResponse<ResponseData>(new ResponseData("Telefone verificado com sucesso."), 200);

        #endregion
    }
}
using OldCare.Contexts.AccountContext.UseCases.Details.Contracts;
using OldCare.Contexts.AccountContext.UseCases.Details.Models;
using OldCare.Contexts.SharedContext.Services.Log.Contracts;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using OldCare.Contexts.SharedContext.Enums;

namespace OldCare.Contexts.AccountContext.UseCases.Details;

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
        #region 01. Get by username

        DetailsModel? user;

        try
        {
            user = await _repository.GetUserByUsernameAsync(request.Email);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ELogType.Error, $"{request.Email} | Ocorreu um erro ao recuperar as informações da conta.");
            return new BaseResponse<ResponseData>(ex);
        }

        #endregion
        
        #region 02. Verify if user exists

        if (user is null)
        {
            await _logService.LogAsync(ELogType.Error, $"{request.Email} | Conta não encontrada.");
            return new BaseResponse<ResponseData>("Conta não encontrada", "765da45a", 404);
        }

        #endregion

        #region 05. Retornar mensagem de sucesso

        return new BaseResponse<ResponseData>(new ResponseData(user), 200);

        #endregion
    }
}
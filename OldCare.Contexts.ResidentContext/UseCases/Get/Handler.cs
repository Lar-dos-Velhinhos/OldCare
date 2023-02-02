using MediatR;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Get.Contracts;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.UseCases;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;

namespace OldCare.Contexts.ResidentContext.UseCases.Get;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    #region Private Properties

    private readonly LogService _logService;
    private readonly IRepository _repository;

    #endregion

    #region Constructors

    public Handler(
        LogService logService,
        IRepository repository)
    {
        _logService = logService;
        _repository = repository;
    }

    #endregion

    public async Task<BaseResponse<ResponseData>> Handle(
        Request request,
        CancellationToken cancellationToken)
    {
        #region  01. Create Aggregate Root

        List<Resident?> residents;

        #endregion
        
        #region 02. Create and Populate Aggregate Root

        try
        {
            residents = await _repository.GetAllResidentsOrderedByName(request.Skip, request.Take);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ELogType.LocalException, "❌ Ocorreu um erro ao carregar os registros dos residentes.",
                "73D9DF0B", ex.Message);
            return new BaseResponse<ResponseData>("Ocorreu um erro ao carregar os registros dos residentes.", "73D9DF0B");
        }

        #endregion

        #region 03. Retornar mensagem de sucesso

        await _logService.LogAsync(ELogType.LocalUserActivity, $"✔️ Foram carregados {residents.Count} registros de residentes.",
            "68C4F652");
        return new BaseResponse<ResponseData>(new ResponseData($"Foram carregados {residents.Count} registros de residentes.", residents));

        #endregion
    }
}
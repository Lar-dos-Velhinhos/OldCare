using MediatR;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Get.Contracts;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.Extensions;
using OldCare.Contexts.SharedContext.UseCases;
using OldCare.Contexts.SharedContext.ValueObjects.Exceptions;
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
            if (request.OnlyActives)
                residents = await _repository.GetActiveResidentsOrderedByName(request.Skip, request.Take);
            else
                residents = await _repository.GetResidentsOrderedByName(request.Skip, request.Take);
            
            ListException.ThrowIfEmpty(residents);
        }
        catch (ListException e)
        {
            await _logService.LogAsync(ELogType.Error, $"❌ {e.Message}",
                "7C296A3E");
            return new BaseResponse<ResponseData>(e.Message, "7C296A3E");
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ELogType.Error, "❌ Ocorreu um erro ao carregar os registros dos residentes.",
                "73D9DF0B", ex.Message);
            return new BaseResponse<ResponseData>("Ocorreu um erro ao carregar os registros dos residentes.", "73D9DF0B");
        }

        #endregion

        #region 03. Retornar mensagem de sucesso

        await _logService.LogAsync(ELogType.UserActivity, $"✔️ Foi carregado {residents.Count} registro de residente."
                .ToMany(residents.Count, $"✔️ Foram carregados {residents.Count} registros de residentes."),
            "68C4F652");
        return new BaseResponse<ResponseData>(
            new ResponseData($"Foi carregado {residents.Count} registro de residente."
                .ToMany(residents.Count, $"Foram carregados {residents.Count} registros de residentes."), residents));

        #endregion
    }
}
using MediatR;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.GetDetails.Contracts;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.UseCases;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;


namespace OldCare.Contexts.ResidentContext.UseCases.GetDetails;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
	#region Private Properties

	private readonly LogService _logService;
	private readonly IRepository _repository;

    #endregion

    #region Public Construtors

    public Handler(LogService logService, IRepository repository) =>
		(_logService, _repository) = (logService, repository);

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Create Aggregate Root

        Resident resident = new();

        #endregion

        #region 02. Populate Agregate Root

        try
        {
            resident = await _repository.GetDetailsByIdAsync(request.ResidentId);

            if(resident == null)
            {
                await _logService.LogAsync(
                    ELogType.UserActivity,
                    "👤 Residente não localizado",
                    "F3C4FE78");

                return new BaseResponse<ResponseData>(
                    "Residente não localizado",
                    "F3C4FE78");
            }

        }
        catch (Exception exception)
        {
            await _logService.LogAsync(ELogType.Error,"❌ Ocorreu um erro ao carregar os dados do residente",
                "5AD233E0", exception.Message);
            return new BaseResponse<ResponseData>("Ocorreu um erro ao carregar os dados do residente",
                "5AD233E0", 500);
        }

        #endregion

        #region 03. Return success response

        await _logService.LogAsync(
            ELogType.UserActivity,
            "Dados carregados do residente com sucesso",
            "7E75FD32");

        return new BaseResponse<ResponseData>(
            "Dados do residente carregados com sucesso",
            "7E75FD32", 200);

        #endregion
    }

    #endregion
}

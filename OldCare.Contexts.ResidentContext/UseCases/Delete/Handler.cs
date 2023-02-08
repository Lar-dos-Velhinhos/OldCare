using MediatR;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Delete.Contracts;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.UseCases;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;

namespace OldCare.Contexts.ResidentContext.UseCases.Delete;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    #region Private Properties

    private readonly LogService _logService;
    private readonly IRepository _repository;

    #endregion

    #region Public Constructors

    public Handler(LogService logService, IRepository repository)
        => (_logService, _repository) = (logService, repository);

    #endregion

    #region Overloads

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Create Aggregate Root

        Resident? resident = new();

        #endregion
        
        #region 02. Check if resident already exists

        var result = await _repository.CheckResidentExistsByIdAsync(request.ResidentId);

        if (!result)
        {
            await _logService.LogAsync(ELogType.Error, $"❌ Nenhum residente com este identificador foi encontrada.", "305FC58A", request.ResidentId.ToString());
            return new BaseResponse<ResponseData>("Nenhum residente com este identificador foi encontrado.", "305FC58A");
        }

        #endregion

        #region 03. Populate Aggregate Root

        resident = await _repository.GetResidentByIdAsync(request.ResidentId);

        if (resident == null)
        {
            await _logService.LogAsync(ELogType.ApplicationEvent, $"🌐 Não foi possível carregar as informações.", "97C98BAB");
            return new BaseResponse<ResponseData>("Não foi possível carregar as informações.", "97C98BAB");
        }

        #endregion

        #region 04. Mark Resident as deleted

        resident.Delete();

        #endregion
        
        #region 05. Persist data

        try
        {
            await _repository.UpdateAsync(resident);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ELogType.ApplicationEvent, $"🌐 - Não foi possível remover o residente.", "FD6DB8DE", ex.Message);
            return new BaseResponse<ResponseData>("🌐 - Não foi possível remover o residente.", "FD6DB8DE");
        }
        
        #endregion

        #region 06. Return success response

        await _logService.LogAsync(ELogType.UserActivity, $"🗑️ **{resident.Person.Name}** - Residente removido com sucesso.");
        return new BaseResponse<ResponseData>(new ResponseData("Residente removido com sucesso."), 201);

        #endregion
    }

    #endregion
}
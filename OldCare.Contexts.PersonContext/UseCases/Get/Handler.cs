using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.PersonContext.UseCases.Get.Contracts;
using OldCare.Contexts.SharedContext.Enums;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;

namespace OldCare.Contexts.PersonContext.UseCases.Get;

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

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Create Aggregate Root

        var persons = new List<Person?>();
        
        #endregion

        #region Populate list

        try
        {
            persons = await _repository.GetAll(request.Skip, request.Take);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ELogType.Error, "❌ Ocorreu um erro ao carregar os registros.", "400168D3", ex.Message);
            return new BaseResponse<ResponseData>("Ocorreu um erro ao carregar os registros.", "400168D3");
        }

        #endregion
        
        #region Return Success Message

        await _logService.LogAsync(ELogType.ApplicationEvent, "📃 Registros obtidos com sucesso", "Pessoas", null);
        return new BaseResponse<ResponseData>(new ResponseData($"Registros obtidos com sucesso.", persons), 201);

        #endregion
    }
}
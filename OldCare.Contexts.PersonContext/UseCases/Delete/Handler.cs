using MediatR;
using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.PersonContext.UseCases.Delete.Contracts;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.UseCases;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;

namespace OldCare.Contexts.PersonContext.UseCases.Delete;

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

    #region Overloads

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Create Aggregate Root

        Person person = new();

        #endregion

        #region 02. Check if person already exists

        var result = await _repository.CheckAccountExistsByIdAsync(request.Id);

        if (!result)
        {
            await _logService.LogAsync(ELogType.LocalException, $"❌ - Nenhuma pessoa com este identificador foi encontrada.", "E52D25DC", request.Id.ToString());
            return new BaseResponse<ResponseData>("Nenhuma pessoa com este identificador foi encontrada..", "ACCE2B08");
        }
        
        #endregion

        #region 03. Populate Aggregate Root

        person = await _repository.GetByIdAsync(request.Id);

        #endregion

        #region 04. Mark Person as deleted

        person.Delete();

        #endregion

        #region 05. Persist data

        try
        {
            await _repository.UpdateAsync(person);
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ELogType.LocalException, $"❌ {request.Id} - Não foi possível marcar a pessoa como deletada.", "D01A2CC4", ex.Message);
            return new BaseResponse<ResponseData>("Não foi possível salvar as informações.", "D01A2CC4");
        }

        #endregion

        #region 06. Return success response

        return new BaseResponse<ResponseData>(new ResponseData("Pessoa removida com sucesso!"), 201);

        #endregion
    }

    #endregion
}
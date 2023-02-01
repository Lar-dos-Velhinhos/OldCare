using System.Text.Json;
using MediatR;
using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.UseCases;
using OldCare.Contexts.PersonContext.UseCases.Modify.Contracts;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.ValueObjects;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;

namespace OldCare.Contexts.PersonContext.UseCases.Modify;

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

    #region Public Methods

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Create Aggregate Root

        Person? person = new();

        #endregion

        #region 02. Populate Aggregate Root

        person = await _repository.GetByIdAsync(request.PersonId);

        if (person == null)
        {
            await _logService.LogAsync(
                ELogType.LocalUserActivity,
                "👤 Pessoa não localizada.",
                "2F9A7E0C");
            
            return new BaseResponse<ResponseData>(
                "Pessoa não localizada.",
                "2F9A7E0C");
        }

        #endregion

        #region 03. Attach Address

        var address = new Address(
            request.City,
            request.District,
            request.Number,
            request.State,
            request.Street,
            request.ZipCode,
            request.Code,
            request.Complement,
            request.Country,
            request.Notes);

        person.ModifyAddress(address);

        #endregion

        #region 04. Persist Data

        _repository.UpdateAsync(person);

        #endregion

        #region 05. Return success response

        await _logService.LogAsync(
            ELogType.LocalUserActivity,
            "👤 Endereço atualizado com sucesso.",
            person.Name,
            JsonSerializer.Serialize(person));
        
        return new BaseResponse<ResponseData>(
            new ResponseData($"{person.Name} - Endereço atualizado com sucesso!"),
            201);

        #endregion
    }
    
    #endregion 
}
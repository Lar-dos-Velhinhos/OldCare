using MediatR;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Create.Contracts;
using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.UseCases;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;

namespace OldCare.Contexts.ResidentContext.UseCases.Create;

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
    
    #region Methods

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Create Aggregate Root

        Resident resident = new();

        #endregion

        #region 02. Check if resident already exists

        var result = await _repository.CheckResidentExistsByPersonIdAsync(request.PersonId);

        if (result)
        {
            await _logService.LogAsync(
                ELogType.Error,
                "👤 Residente já cadastrado",
                "AF59DD56", null);
            
            return new BaseResponse<ResponseData>("Residente já cadastrado", "AF59DD56");    
        }

        #endregion

        #region 03. Populate Aggregate Root

        var person = await _repository.GetPersonByIdAsync(request.PersonId);

        resident = new(person);
        
        try
        {
            resident.ChangeInformation(
                request.AdmissionDate,
                request.EducationLevel,
                request.DepartureDate,
                request.HealthInsurance,
                request.IsDeleted,
                request.MaritalStatus,
                request.Mobility,
                request.Note,
                request.Profession,
                request.SUS,
                request.VoterRegCardNumber);
        }
        catch
        {
            return new BaseResponse<ResponseData>(
                "Não foi possível salvar as informações pessoais.",
                "DC3E915F");
        }

        #endregion

        #region 03. Persist Data

        try
        {
            await _repository.CreateAsync(resident);
        }
        catch
        {
            return new BaseResponse<ResponseData>(
                "Não foi possível salvar as informações", "16C8D89F");
        }

        #endregion

        #region 04.Return success response

        return new BaseResponse<ResponseData>(
            new ResponseData(
                $"{resident.Person.Name} - Cadastro efetuado com sucesso!"),
                    201);

        #endregion
    }

    #endregion
}
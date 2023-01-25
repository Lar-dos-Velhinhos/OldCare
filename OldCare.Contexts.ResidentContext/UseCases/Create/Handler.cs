using MediatR;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Create.Contracts;
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

    public async Task<BaseResponse<ResponseData>> Handle(Request request,
        CancellationToken cancellationToken)
    {
        #region 01. Create Aggregate Root

        Resident resident = new();

        #endregion

        #region 02. Check if resident already exists

        var result = await _repository.CheckResidentExistsAsync(request.Person.Id);

        if (result)
        {
            await _logService.LogAsync(
                ELogType.LocalException,
                $"{request.Person.Name.FirstName} {request.Person.Name.LastName} - Residente já cadastrado",
                "9A6370AA", null);
            return new BaseResponse<ResponseData>("Residente já cadastrado", "9A6370AA");
        }

        #endregion

        #region 03 Attach resident personal data

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
        
        

        #region 04. Persist Data

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

        #region 05.Return success response

        return new BaseResponse<ResponseData>(
            new ResponseData(
                $"{resident.Person.Name} - Cadastro efetuado com sucesso!"),
                    201);

        #endregion
    }

    #endregion
}
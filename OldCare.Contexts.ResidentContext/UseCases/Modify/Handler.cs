using MediatR;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Modify.Contracts;
using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.UseCases;
using OldCare.Contexts.SharedContext.ValueObjects;
using System.Text.Json;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;

namespace OldCare.Contexts.ResidentContext.UseCases.Modify;

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

    #region Public Methods

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Create Aggregate Root

        Resident? resident = new();

        #endregion

        #region 02. Populate Aggregate Root

        try
        {
            resident = await _repository.GetResidentByIdAsync(request.ResidentId);

            if(resident == null)
            {
                await _logService.LogAsync(
                    ELogType.UserActivity,
                    "👤 Residente não localizado.",
                    "51E26937");

                return new BaseResponse<ResponseData>(
                    "Residente não localizado.",
                    "51E26937");
            }
        }
        catch (Exception exception)
        {
            await _logService.LogAsync(ELogType.Error, "❌ Ocorreu um erro ao carregar os dados do residente.",
                "C9E34062", exception.Message);
            return new BaseResponse<ResponseData>("Ocorreu um erro ao carregar os dados do residente.", "C9E34062", 500);
        }
        Person? person = new();
        try
        {
            person = await _repository.GetPersonByIdAsync(request.PersonId);

            if (person == null)
            {
                await _logService.LogAsync(
                ELogType.UserActivity,
                "Pessoa não localizada.",
                "D7DAD1DD");
                return new BaseResponse<ResponseData>("Residente não localizado.", "D7DAD1DD");
            }
        }
        catch (Exception exception)
        {
            await _logService.LogAsync(ELogType.Error, "❌ Ocorreu um erro ao carregar os dados da pessoa.",
                "77702ADF", exception.Message);
            return new BaseResponse<ResponseData>("Ocorreu um erro ao carregar os dados da pessoa.", "77702ADF", 500);
        }

        #endregion

        #region 03 Attach Address

        try
        {
            var address = new Address(
               request.AddressCity,
               request.AddressDistrict,
               request.AddressNumber,
               request.AddressState,
               request.AddressStreet,
               request.AddressZipCode,
               request.AddressCode,
               request.AddressComplement,
               request.AddressCountry,
               request.AddressNotes);

            person.ModifyAddress(address);
        }
        catch (Exception exception)
        {
            await _logService.LogAsync(ELogType.ApplicationEvent,
                "❌ Não foi possível modificar o endereço do residente.",
                "5333FF34", exception.Message);

            return new BaseResponse<ResponseData>("Não foi possível modificar o endereço do residente.", "5333FF34", 500);
            
        }

        #endregion

        #region 04 Attach Person Data

        person.ChangeInformation(
            request.BirthDate,
            request.Citizenship,
            request.FatherName,
            request.Gender,
            request.MotherName,
            request.Nationality,
            request.Obs);

        #endregion

        #region 05. Attach Resident Data

        try
        {
            resident.ChangeInformation(
            request.AdmissionDate,
            request.EducationLevel,
            request.HealthInsurance,
            request.IsDeleted,
            request.MaritalStatus,
            request.Mobility,
            request.Note,
            request.Profession,
            request.SUS,
            request.VoterRegCardNumber);

        }
        catch (Exception)
        {
            return new BaseResponse<ResponseData>(
                "Não foi possível salvar as informações do residente.",
                "30FDF19A");
        }

        #endregion

        #region 06. Attach Bedroom

        resident.ModifyBedroom(request.Bedroom);

        #endregion

        #region 07. Attach Occurrence

        resident.ChangeOccurrences(request.Occurrences);

        #endregion

        #region 04. Persist Data

        await _repository.UpdateAsync(resident);

        #endregion

        #region 05. Return success response

        await _logService.LogAsync(
            ELogType.UserActivity,
            "👤 Dados do residente atualizados com sucesso!",
            resident.Person.Name);
            JsonSerializer.Serialize(resident);

        return new BaseResponse<ResponseData>(
            new ResponseData($"{resident.Person.Name} - Dados do residente atualizados com sucesso!"),
            201);

        #endregion
    }

    #endregion
}

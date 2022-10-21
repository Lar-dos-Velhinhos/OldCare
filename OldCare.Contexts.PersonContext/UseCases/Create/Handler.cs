using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using OldCare.Contexts.PersonContext.Entities;
using OldCare.Contexts.PersonContext.UseCases.Create.Contracts;
using OldCare.Contexts.SharedContext.ValueObjects;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;
using EllipticCurve.Utils;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;

namespace OldCare.Contexts.PersonContext.UseCases.Create;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    #region Private Properties
    private readonly IRepository _repository;

    #endregion

    #region Constructors

    public Handler(LogService logService, IRepository repository)
        => _repository = repository;

    #endregion

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Create aggregate root

        Person person = new();

        #endregion

        #region 02. Check if person already exists

        var result = await _repository.CheckAccountExistsAsync(request.FirstName, request.LastName, request.BirthDate);
        
        if (result)
            return new BaseResponse<ResponseData>("Pessoa já cadastrada.", "e52d25dc");

        #endregion

        #region 03. Attach person name

        try
        {
            person.ChangeName(request.FirstName, request.LastName);
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>("Não foi possível salvar o nome.", "1fa4222b");
        }

        #endregion

        #region 04. Attach personal data

        try
        {
            person.ChangeInformation(
                request.BirthDate,
                request.Citizenship,
                request.Gender,
                request.Nationality,
                request.Obs);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível salvar as informações pessoais.", "d91cdebc");
        }

        #endregion

        #region 05. Attach documents

        try
        {
            // person.AddDocuments(request.Documents);
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>("Não foi possível salvar os documentos.", "7d2f89cb");
        }

        #endregion

        #region 06.  Check if address is empty

        if(string.IsNullOrEmpty(request.Street) && string.IsNullOrEmpty(request.District))
            return new BaseResponse<ResponseData>(new ResponseData("", request), 201);

        #endregion

        #region 07. Attach address

        try
        {
            Address address = new(
                request.ZipCode,
                request.Street,
                request.AddressNumber,
                request.District,
                request.City,
                request.State,
                request.Country,
                request.Complement,
                request.Code,
                request.Notes);

            person.ChangeAddress(address);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível salvar o endereço.", "f00467f2");
        }

        #endregion

        //#region 08. Attach person profile photo

        //try
        //{
        //    person.ChangePhoto(request.Photo);
        //}
        //catch (Exception ex)
        //{
        //    return new BaseResponse<ResponseData>(ex.Message, "3234a0b3");
        //}

        //#endregion

        #region 06. Persist data

        try
        {
            await _repository.CreateAsync(person);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível salvar as informações.", "ccee74a1");
        }

        #endregion

        #region 07. Return success response

        return new BaseResponse<ResponseData>(new ResponseData("Bem vindo(a) ao OldCare!"), 201);

        #endregion
    }
}
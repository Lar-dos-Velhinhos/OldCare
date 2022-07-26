using System.Globalization;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using OldCare.Contexts.PersonContext.Entities;
using OldCare.Contexts.PersonContext.UseCases.Create.Contracts;
using OldCare.Contexts.SharedContext.ValueObjects;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;

namespace OldCare.Contexts.PersonContext.UseCases.Create;

public class Handler : IRequestHandler<Request, BaseResponse<ResponseData>>
{
    #region Private Properties

    private readonly LogService _logService;
    private readonly IRepository _repository;

    #endregion

    #region Constructors

    public Handler(LogService logService, IRepository repository)
    {
        _logService = logService;
        _repository = repository;
    }

    #endregion

    public async Task<BaseResponse<ResponseData>> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Create aggregate root

        Person person = new Person();

        #endregion

        #region 02. Check if person already exists

        var result = await _repository.CheckAccountExistsAsync(request.FirstName, request.LastName, request.BirthDate);
        
        if (!result)
            return new BaseResponse<ResponseData>("Pessoa já cadastrada.", "e52d25dc");
        
        #endregion

        #region 03. Generate address

        Address address = new Address(
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

        #endregion

        #region 04. Generate documents

        // TODO: Concluir

        #endregion

        #region 03. Persist data

        try
        {
            await _repository.CreateAsync(person);
        }
        catch
        {
            return new BaseResponse<ResponseData>("Não foi possível salvar as informações.", "ccee74a1");
        }

        #endregion

        #region 08. Return success response

        return new BaseResponse<ResponseData>(new ResponseData("Bem vindo(a) ao OldCare!"), 201);

        #endregion
    }
}
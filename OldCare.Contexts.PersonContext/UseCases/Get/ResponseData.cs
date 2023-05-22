using OldCare.Contexts.SharedContext.Entities;

using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.PersonContext.UseCases.Get;

public class ResponseData : IResponseData
{
    #region Constructors

    public ResponseData(string message) => Message = message;

    public ResponseData(string message, List<Person?> persons)
    {
        Message = message;
        Persons = persons;
    }

    #endregion

    #region Public Properties

    public string? Message { get; }
    public List<Person?> Persons { get; private set; }

    #endregion
}
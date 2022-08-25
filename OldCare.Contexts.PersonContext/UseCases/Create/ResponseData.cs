using OldCare.Contexts.PersonContext.Entities;

using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.PersonContext.UseCases.Create;

public class ResponseData : IResponseData
{
    #region Ctors
    public ResponseData(string message) => Message = message;

    public ResponseData(string message, Person person)
    {
        Message = message;
        Person = person;
    }

    #endregion

    public string Message { get; }
    public Person Person { get; }       
}
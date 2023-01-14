using OldCare.Contexts.PersonContext.Entities;

using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.PersonContext.UseCases.Create;

public class ResponseData : IResponseData
{
    #region Ctors
    public ResponseData(string message) => Message = message;

    public ResponseData(string message, Request request)
    {
        Message = message;
        Request = request;
    }

    #endregion

    public string Message { get; }
    public Request  Request { get; }       
}
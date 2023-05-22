using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.ResidentContext.UseCases.Create;

public class ResponseData : IResponseData
{
    #region Constructors

    public ResponseData(string message) => Message = message;

    public ResponseData(string message, Request request)
    {
        Message = message;
        Request = request;
    }
    
    #endregion

    #region Public Properties

    public string Message { get; }
    
    public Request Request { get; }

    #endregion
}
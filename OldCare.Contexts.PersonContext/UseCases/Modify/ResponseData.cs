using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.PersonContext.UseCases.Modify;

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

    #region Public proprerties

    public string Message { get; set; }
    public Request Request { get; set; }

    #endregion
}
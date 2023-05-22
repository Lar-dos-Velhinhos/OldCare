using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.ResidentContext.UseCases.Delete;

public class ResponseData : IResponseData
{
    #region Public Constructors

    public ResponseData(string message) => Message = message;

    public ResponseData(string message, Request request)
        => (Message, Request) = (message, request);

    #endregion

    #region Public Properties

    public string Message { get; }
    public Request Request { get; }

    #endregion
}
using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.AccountContext.UseCases.VerifyPhone;

public class ResponseData : IResponseData
{
    public ResponseData(string message) => Message = message;
    public bool IsVerified { get; set; }
    public string Message { get; }
}
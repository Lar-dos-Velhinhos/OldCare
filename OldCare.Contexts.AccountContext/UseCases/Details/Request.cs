using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.Details;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    public Request()
    {
        
    }
    public Request(string email) => Email = email;

    public string Email { get; set; } = string.Empty;
}
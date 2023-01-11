using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.PersonContext.UseCases.Get;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    public int Skip { get; set; }
    public int Take { get; set; }
}
using MediatR;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.Contexts.ResidentContext.UseCases.Get;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    public int Skip { get; set; }
    public int Take { get; set; }
    public bool OnlyActives { get; set; } = true;
}
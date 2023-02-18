using MediatR;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.Contexts.ResidentContext.UseCases.GetDetails;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    public Guid ResidentId { get; private set; }
}

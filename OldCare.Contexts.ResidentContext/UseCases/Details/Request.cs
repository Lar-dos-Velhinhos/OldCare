using MediatR;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.Contexts.ResidentContext.UseCases.Details;

public class Request : IRequest<BaseResponse<ResponseData>>
{
	public Request(Guid residentId) => ResidentId = residentId;

    public Guid ResidentId { get; set; }
}

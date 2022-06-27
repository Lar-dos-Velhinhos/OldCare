using MediatR;
using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.Contexts.AccountContext.UseCases.ListResidents;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    public List<Resident> Residents { get; set; }
}
using MediatR;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.Contexts.ResidentContext.UseCases.Delete;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    #region Public Constructors

    public Request(Guid residentId) => ResidentId = residentId;

    #endregion

    #region Public Properties

    public Guid ResidentId { get; set; }

    #endregion
}
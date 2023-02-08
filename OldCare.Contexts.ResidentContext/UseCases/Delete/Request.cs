using MediatR;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.Contexts.ResidentContext.UseCases.Delete;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    #region Public Properties

    public Guid ResidentId { get; set; }

    #endregion
}
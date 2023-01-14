using MediatR;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.Contexts.PersonContext.UseCases.Delete;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    #region Public Properties

    public Guid Id { get; set; }

    #endregion
}
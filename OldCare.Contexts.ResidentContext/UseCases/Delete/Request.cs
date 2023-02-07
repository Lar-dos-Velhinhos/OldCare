using MediatR;

namespace OldCare.Contexts.ResidentContext.UseCases.Delete;

public class Request : IRequest
{
    #region Public Properties

    public Guid ResidentId { get; set; }

    #endregion
}
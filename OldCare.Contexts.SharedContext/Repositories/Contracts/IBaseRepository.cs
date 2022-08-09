using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.SharedContext.Repositories.Contracts;

public interface IBaseRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
{
}
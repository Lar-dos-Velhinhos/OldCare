using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.SharedContext.Repositories.Contracts;

namespace OldCare.Contexts.AccountContext.UseCases.Authenticate.Contracts;

public interface IRepository : IBaseRepository<Person>
{
    Task<User?> GetByUserNameAsync(string userName);
    Task UpdateAsync(User user);
    Task<string[]?> GetRolesAsync(Guid userId);
}
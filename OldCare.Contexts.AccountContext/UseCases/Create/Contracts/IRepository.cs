using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.SharedContext.Repositories.Contracts;

namespace OldCare.Contexts.AccountContext.UseCases.Create.Contracts;

public interface IRepository : IBaseRepository<User>
{
    Task CreateAsync(User user);
    Task<bool> CheckAccountExistsAsync(string username);
    Task<bool> CheckAccountIsBlackListedAsync(string username);
}
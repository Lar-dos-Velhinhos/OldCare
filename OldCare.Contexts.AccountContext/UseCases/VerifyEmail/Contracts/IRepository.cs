using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.SharedContext.Repositories.Contracts;

namespace OldCare.Contexts.AccountContext.UseCases.VerifyEmail.Contracts;

public interface IRepository : IBaseRepository<User>
{
    Task<bool> CheckAccountIsBlackListedAsync(string username);
    Task<User?> GetUserByUsernameAsync(string username);
    Task SaveAsync(User user);
}
using OldCare.Contexts.AccountContext.Entities;

namespace OldCare.Contexts.AccountContext.UseCases.RequestPasswordResetCode.Contracts;

public interface IRepository
{
    Task<bool> CheckAccountIsBlackListedAsync(string username);
    Task<User?> GetUserByUsernameAsync(string username);
}
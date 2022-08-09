using OldCare.Contexts.AccountContext.Entities;

namespace OldCare.Contexts.AccountContext.UseCases.ResetPassword.Contracts;

public interface IRepository
{
    Task<User?> GetUserByUsernameAsync(string username);
    Task SaveAsync(User user);
}
using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.SharedContext.Repositories.Contracts;

namespace OldCare.Contexts.AccountContext.UseCases.ChangePassword.Contracts;

public interface IRepository : IBaseRepository<Person>
{
    Task<User?> GetStudentByUsernameAsync(string username);
    Task SaveAsync(User user);
}
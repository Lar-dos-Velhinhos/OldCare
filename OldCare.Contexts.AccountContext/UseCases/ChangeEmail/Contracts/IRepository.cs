using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.SharedContext.Repositories.Contracts;

namespace OldCare.Contexts.AccountContext.UseCases.ChangeEmail.Contracts;

public interface IRepository : IBaseRepository<Student>
{
    Task<bool> CheckAccountExistAsync(string email);
    Task<bool> CheckAccountIsBlackListedAsync(string email);
    Task<Student?> GetStudentByEmailAsync(string email);
    Task SaveAsync(Student student);
}
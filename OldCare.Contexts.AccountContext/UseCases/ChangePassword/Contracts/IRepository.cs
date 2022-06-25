using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.SharedContext.Repositories.Contracts;

namespace OldCare.Contexts.AccountContext.UseCases.ChangePassword.Contracts;

public interface IRepository : IBaseRepository<Student>
{
    Task<Student?> GetStudentByEmailAsync(string email);
    Task SaveAsync(Student student);
}
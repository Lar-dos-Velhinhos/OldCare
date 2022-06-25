using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.SharedContext.Repositories.Contracts;

namespace OldCare.Contexts.AccountContext.UseCases.Authenticate.Contracts;

public interface IRepository : IBaseRepository<Student>
{
    Task<Student?> GetByEmailAsync(string email);
    Task UpdateAsync(Student student);
    Task<string[]?> GetRolesAsync(Guid userId);
}
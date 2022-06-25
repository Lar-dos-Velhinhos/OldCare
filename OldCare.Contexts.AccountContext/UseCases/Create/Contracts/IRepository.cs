using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.SharedContext.Repositories.Contracts;

namespace OldCare.Contexts.AccountContext.UseCases.Create.Contracts;

public interface IRepository : IBaseRepository<Student>
{
    Task CreateAsync(Student student);
    Task<IEnumerable<Tag>> GetTagsAsync();
    Task<bool> CheckAccountExistsAsync(string email);
    Task<bool> CheckAccountIsBlackListedAsync(string email);
}
using OldCare.Contexts.AccountContext.Entities;

namespace OldCare.Contexts.AccountContext.UseCases.Edit.Contracts;

public interface IRepository
{
    Task<Student?> GetStudentByEmailAsync(string email);
    Task SaveAsync(Student student);
}
using OldCare.Contexts.AccountContext.Entities;

namespace OldCare.Contexts.AccountContext.UseCases.ResetPassword.Contracts;

public interface IRepository
{
    Task<Student?> GetStudentByEmailAsync(string email);
    Task SaveAsync(Student student);
}
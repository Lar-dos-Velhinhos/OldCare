using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.VerifyPhone.Contracts;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data.Contexts.AccountContext.UseCases.VerifyPhone;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;

    public async Task<Student?> GetStudentByEmailAsync(string email) 
        => await _context.Students.Where(x => x.Email.Address == email.ToLower()).FirstOrDefaultAsync();

    public async Task SaveAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }
}
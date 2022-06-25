using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.ChangeEmail.Contracts;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data.Contexts.AccountContext.UseCases.ChangeEmail;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public async Task<bool> CheckAccountExistAsync(string email)
        => await _context.Students.AnyAsync(x => x.Email.Address == email.ToLower());

    public Repository(DataContext context) => _context = context;

    public async Task<bool> CheckAccountIsBlackListedAsync(string email)
        => await _context.BlackLists.AnyAsync(x => x.Email.Address == email.ToLower());

    public async Task<Student?> GetStudentByEmailAsync(string email)
        => await _context.Students
            .Include(x => x.User)
            .Where(x => x.Email.Address == email.ToLower()).FirstOrDefaultAsync();

    public async Task SaveAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }
}
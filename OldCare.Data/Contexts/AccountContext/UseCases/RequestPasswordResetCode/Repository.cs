using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.RequestPasswordResetCode.Contracts;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data.Contexts.AccountContext.UseCases.RequestPasswordResetCode;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;
    
    public async Task<bool> CheckAccountIsBlackListedAsync(string email)
        => await _context.BlackLists.AnyAsync(x => x.Email.Address == email.ToLower());

    public async Task<Student?> GetStudentByEmailAsync(string email) 
        => await _context.Students.Where(x => x.Email.Address == email.ToLower()).FirstOrDefaultAsync();
}
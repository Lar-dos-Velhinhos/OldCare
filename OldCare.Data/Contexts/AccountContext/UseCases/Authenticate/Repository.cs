using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.Authenticate.Contracts;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data.Contexts.AccountContext.UseCases.Authenticate;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) 
        => _context = context;

    public async Task<Student?> GetByEmailAsync(string email) =>
        await _context
            .Students
            .Include(x => x.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.Address == email);

    public async Task UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task<string[]?> GetRolesAsync(Guid userId)
    {
        return await _context
            .UserRoles
            .Include(x => x.Role)
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .Select(x => x.Role.Name)
            .ToArrayAsync();
    }
}
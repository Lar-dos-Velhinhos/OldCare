using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.Authenticate.Contracts;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data.Contexts.AccountContext.UseCases.Authenticate;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) 
        => _context = context;

    public async Task<User?> GetByUserNameAsync(string email) =>
        await _context
            .Users
            .Include(x => x.Person)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Username.Address == email);

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
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
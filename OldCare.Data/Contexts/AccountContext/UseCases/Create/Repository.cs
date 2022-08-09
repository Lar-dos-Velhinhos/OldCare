using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.Create.Contracts;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data.Contexts.AccountContext.UseCases.Create;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;

    public async Task CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckAccountExistsAsync(string username)
    {
        if (await _context.Users.AnyAsync(x => x.Username.Address == username.ToLower()))
            return true;

        return await _context.Users.AnyAsync(x => x.Username.Address == username.ToLower());
    }

    public async Task<bool> CheckAccountIsBlackListedAsync(string username)
        => await _context.BlackLists.AnyAsync(x => x.Email.Address == username.ToLower());
}
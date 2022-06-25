using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.Create.Contracts;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data.Contexts.AccountContext.UseCases.Create;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;

    public async Task<IEnumerable<Tag>> GetTagsAsync()
    {
        return await _context
            .Tags
            .Where(x => x.Slug == "newbie" ||
                        x.Slug == "email_unconfirmed" ||
                        x.Slug == "newsletter" ||
                        x.Slug == "promos")
            .ToListAsync();
    }

    public async Task CreateAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckAccountExistsAsync(string email)
    {
        if (await _context.Students.AnyAsync(x => x.Email.Address == email.ToLower()))
            return true;

        return await _context.Users.AnyAsync(x => x.Username.Address == email.ToLower());
    }

    public async Task<bool> CheckAccountIsBlackListedAsync(string email)
        => await _context.BlackLists.AnyAsync(x => x.Email.Address == email.ToLower());
}
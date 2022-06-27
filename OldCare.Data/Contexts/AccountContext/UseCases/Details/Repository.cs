using OldCare.Contexts.AccountContext.UseCases.Details.Contracts;
using OldCare.Contexts.AccountContext.UseCases.Details.Models;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data.Contexts.AccountContext.UseCases.Details;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;

    public async Task<DetailsModel?> GetUserByUsernameAsync(string username)
        => await _context
            .Users
            .AsNoTracking()
            .Where(x => x.Username.Address == username.ToLower())
            .Select(x => new DetailsModel
            {
                Id = x.Id,
                Email = x.Username.Address,
                Documents = x.Person.Documents,
                Phone = x.Person.Phone!.Number,
                Birthdate = x.Person.BirthDate,
                FirstName = x.Person.Name.FirstName,
                LastName = x.Person.Name.LastName,
                CreatedAt = x.Tracker.CreatedAt
            })
            .FirstOrDefaultAsync();
}
using OldCare.Contexts.PersonContext.Entities;
using OldCare.Contexts.PersonContext.UseCases.Create.Contracts;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data.Contexts.PersonContext.UseCases.Create;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;

    public async Task CreateAsync(Person person)
    {
        await _context.People.AddAsync(person);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckAccountExistsAsync(string firstName, string lastName, DateTime birthDate)
        => await _context.People.AnyAsync(x =>
            x.BirthDate != null && x.Name.FirstName == firstName && x.Name.LastName == lastName &&
            x.BirthDate.Value.Date == birthDate.Date);
}
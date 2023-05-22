using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.PersonContext.UseCases.Create.Contracts;
using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Data.Contexts.PersonContext.UseCases.Create;

public class Repository : IRepository
{
    #region Private Properties

    private readonly DataContext _context;

    #endregion

    #region Constructors

    public Repository(DataContext context) => _context = context;

    #endregion

    #region Methods

    public async Task<bool> CheckAccountExistsAsync(string firstName, string lastName, DateTime birthDate)
        => await _context.People.AnyAsync(x =>
            x.BirthDate != null && x.Name.FirstName == firstName && x.Name.LastName == lastName &&
            x.BirthDate.Value.Date == birthDate.Date);

    public async Task CreateAsync(Person? person)
    {
        await _context.People.AddAsync(person);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Person? person) => _context.People.Remove(person);

    public async Task<Person> GetByIdAsync(Guid id)
        => await _context.People.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<List<Person?>> GetByNameAsync(Name name)
        => await _context.People
            .Where(p =>p.Name.ToString().Contains(name))
            .ToListAsync();

    public async Task UpdateAsync(Person? person) => _context.People.Update(person);

    #endregion
}
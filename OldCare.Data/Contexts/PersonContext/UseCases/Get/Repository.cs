using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.PersonContext.Entities;
using OldCare.Contexts.PersonContext.UseCases.Get.Contracts;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Data.Contexts.PersonContext.UseCases.Get;

public class Repository : IRepository
{
    #region Private Properties

    private readonly DataContext _context;

    #endregion

    #region Constructors

    public Repository(DataContext context) => _context = context;

    #endregion

    #region Methods

    public Task<Person> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Person>> GetByNameAsync(Name name)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Person>> GetAll(int skip, int take)
        => await _context.People
            .Skip(skip)
            .Take(take)
            .Where(p => p.IsDeleted == false)
            .ToListAsync();

    #endregion
}
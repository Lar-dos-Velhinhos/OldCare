using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.PersonContext.Entities;
using OldCare.Contexts.PersonContext.UseCases.Modify.Contracts;

namespace OldCare.Data.Contexts.PersonContext.UseCases.Modify;

public class Repository : IRepository
{
    #region Private Properties

    private readonly DataContext _context;

    #endregion

    #region Constructors

    public Repository(DataContext context) => _context = context;

    #endregion

    #region Public Methods

    public async Task<bool> CheckAccountExistsByIdAsync(Guid id)
        => await _context.People.AnyAsync(x => x.Id == id && x.IsDeleted != true);

    public async Task UpdateAsync(Person person)
    {
        _context.People.Update(person);
        await _context.SaveChangesAsync();
    }

    #endregion
}
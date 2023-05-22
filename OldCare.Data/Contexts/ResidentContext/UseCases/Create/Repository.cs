using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Create.Contracts;
using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Data.Contexts.ResidentContext.UseCases.Create;

public class Repository : IRepository
{
    #region Private Properties

    private readonly DataContext _context;

    #endregion

    #region Constructors
    
    public Repository(DataContext context) => _context = context;

    #endregion

    #region Public Methods

    public async Task<bool> CheckResidentExistsByPersonIdAsync(Guid personId)
        => await _context.Residents.AnyAsync(x => x.Person.Id == personId && x.IsDeleted != true);

    public async Task CreateAsync(Resident resident)
    {
        await _context.Residents.AddAsync(resident);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Person?> GetPersonByIdAsync(Guid personId)
    => await _context.People.FirstOrDefaultAsync(
        x => x.Id == personId && x.IsDeleted == false);

    #endregion
}
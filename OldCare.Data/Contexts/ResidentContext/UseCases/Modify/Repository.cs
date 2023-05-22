using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Modify.Contracts;
using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Data.Contexts.ResidentContext.UseCases.Modify;

public class Repository : IRepository
{
    #region Private Properties

    private readonly DataContext _context;

    #endregion

    #region Public Constructors

    public Repository(DataContext context)
        => _context = context;

    #endregion

    #region Public Methods

    public async Task<Person?> GetPersonByIdAsync(Guid id)
        => await _context.People.FirstOrDefaultAsync(person => 
            person.Id == id &&
            person.IsDeleted != true);    

    public async Task<Resident?> GetResidentByIdAsync(Guid id)
        => await _context.Residents
        .Include(resident => resident.Person)
        .Include(resident => resident.Bedroom)
        .Include(resident => resident.Occurrences)
            .Where(occurrence => occurrence.IsDeleted == false)
        .FirstOrDefaultAsync(resident =>
            resident.Id == id &&
            resident.IsDeleted != true &&
            resident.Person.IsDeleted != true); 
   
    public async Task UpdateAsync(Resident resident)
    {
        _context.Update(resident);
        await _context.SaveChangesAsync();
    }

    #endregion
}

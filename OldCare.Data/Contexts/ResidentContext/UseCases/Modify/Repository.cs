using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Modify.Contracts;

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

    public async Task<Resident?> GetByIdAsync(Guid id)
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

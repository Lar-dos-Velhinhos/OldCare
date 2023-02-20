using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Delete.Contracts;

namespace OldCare.Data.Contexts.ResidentContext.UseCases.Delete;

public class Repository : IRepository
{
    #region Private Properties

    private readonly DataContext _context;

    #endregion

    #region Public Constructors

    public Repository(DataContext context) => _context = context;

    #endregion

    #region Public Methods

    public async Task<bool> CheckResidentExistsByIdAsync(Guid residentId)
        => await _context.Residents
            .Where(resident => resident.Id == residentId && resident.IsDeleted != true)
            .AnyAsync()
        ;

    public async Task<Resident?> GetResidentByIdAsync(Guid residentId)
        => await _context.Residents
            .Where(resident => resident.Id == residentId && resident.IsDeleted != true)
            .FirstOrDefaultAsync();

    public async Task UpdateAsync(Resident resident)
    {
        _context.Residents.Update(resident);
        await _context.SaveChangesAsync();
    }

    #endregion
}
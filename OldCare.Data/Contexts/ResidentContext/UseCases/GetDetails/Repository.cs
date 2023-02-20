using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.GetDetails.Contracts;

namespace OldCare.Data.Contexts.ResidentContext.UseCases.GetDetails;

public class Repository : IRepository
{ 
    #region Private Properties

    private readonly DataContext _context;

    #endregion

    #region Public Constructos

    public Repository(DataContext context) 
        => _context = context;

    #endregion

    #region Public Methods

    public async Task<Resident?> GetDetailsByIdAsync(Guid id)
    => await _context.Residents
            .Include(resident => resident.Person)
            .Include(resident => resident.Bedroom)
            .Include(resident => resident.Occurrences)
                .Where(occurrence => occurrence.IsDeleted != true)
            .FirstOrDefaultAsync(resident =>
                resident.Id == id &&
                resident.IsDeleted != true &&
                resident.Person.IsDeleted != true);

    #endregion
}

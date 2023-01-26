using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.PersonContext.UseCases.Get;
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

    public async Task<bool> CheckResidentExistsByPersonIdAsync(Guid id)
        => await _context.Residents.AnyAsync(x => x.Id == id && x.IsDeleted != true);

    public async Task<Person> GetPersonByIdAsync(Guid id)
        => await _context.People.FirstOrDefaultAsync(
            x => x.Id == id && x.IsDeleted != false);

    public Task CreateAsync(Resident resident)
    {
        throw new NotImplementedException();
    }

    #endregion
    
    
}
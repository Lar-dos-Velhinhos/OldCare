using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.ListResidents.Contracts;

namespace OldCare.Data.Contexts.AccountContext.UseCases.ListResidents;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;

    public Task<List<Resident>> GetAllResidentsOrderedByName()
        => _context.Residents
            .AsNoTracking()
            .OrderBy(x => x.Person.Name)
            .ToListAsync();
}
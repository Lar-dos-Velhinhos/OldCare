using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Get.Contracts;

namespace OldCare.Data.Contexts.ResidentContext.UseCases.Get;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;

    public async Task<List<Resident?>> GetAllResidentsOrderedByName(int skip, int take)
        => await _context.Residents
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .Include(r => r.Person)
            .Include(r => r.Bedroom)
            .Include(r => r.Occurrences
                .Where(o => o.IsDeleted == false))
            .Where(r => r.IsDeleted == false && r.Person.IsDeleted == false)
            .ToListAsync();
}
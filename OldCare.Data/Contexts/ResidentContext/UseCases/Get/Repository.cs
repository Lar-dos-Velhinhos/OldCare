using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Get.Contracts;

namespace OldCare.Data.Contexts.ResidentContext.UseCases.Get;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;

    public async Task<List<Resident?>> GetResidentsOrderedByName(int skip, int take)
        => await _context.Residents
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .Include(resident => resident.Person)
            .Include(resident => resident.Bedroom)
            .Include(resident => resident.Occurrences
                .Where(occurrence => occurrence.IsDeleted == false))
            .Where(r => r.IsDeleted == false && r.Person.IsDeleted == false)
            .ToListAsync();

    public async Task<List<Resident?>> GetActiveResidentsOrderedByName(int skip, int take)
        => (await _context.Residents
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .Include(resident => resident.Person)
            .Include(resident => resident.Bedroom)
            .Include(resident => resident.Occurrences
                .Where(occurrence =>
                    occurrence != null &&
                    occurrence.IsDeleted == false))
            .Where(resident =>
                resident.IsDeleted == false &&
                resident.Person.IsDeleted == false &&
                resident.DepartureDate == null)
            .ToListAsync())!;
}
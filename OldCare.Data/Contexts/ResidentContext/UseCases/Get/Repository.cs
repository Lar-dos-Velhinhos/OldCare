using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Get.Contracts;

namespace OldCare.Data.Contexts.ResidentContext.UseCases.Get;

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
using OldCare.Contexts.AccountContext.UseCases.Details.Contracts;
using OldCare.Contexts.AccountContext.UseCases.Details.Models;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data.Contexts.AccountContext.UseCases.Details;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;

    public async Task<DetailsModel?> GetStudentByEmailAsync(string email)
        => await _context
            .Students
            .AsNoTracking()
            .Where(x => x.Email.Address == email.ToLower())
            .Select(x => new DetailsModel
            {
                Id = x.Id,
                Email = x.Email.Address,
                Document = x.Document!.Number,
                Phone = x.Phone!.Number,
                Birthdate = x.BirthDate,
                FirstName = x.Name.FirstName,
                LastName = x.Name.LastName,
                Title = x.Title,
                Bio = x.Bio,
                CreatedAt = x.Tracker.CreatedAt
            })
            .FirstOrDefaultAsync();
}
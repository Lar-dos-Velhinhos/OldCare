using OldCare.Contexts.AccountContext.UseCases.Details.Models;

namespace OldCare.Contexts.AccountContext.UseCases.Details.Contracts;

public interface IRepository
{
    Task<DetailsModel?> GetStudentByEmailAsync(string email);
}
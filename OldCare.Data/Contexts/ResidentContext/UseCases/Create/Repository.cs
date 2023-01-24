using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Create.Contracts;

namespace OldCare.Data.Contexts.ResidentContext.UseCases.Create;

public class Repository : IRepository
{
    public Task<bool> CheckResidentExistsAsync(string firstName, string lastName, DateTime birthDate)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Resident resident)
    {
        throw new NotImplementedException();
    }
}
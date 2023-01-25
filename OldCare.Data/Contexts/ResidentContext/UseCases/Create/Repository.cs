using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.ResidentContext.UseCases.Create.Contracts;
using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Data.Contexts.ResidentContext.UseCases.Create;

public class Repository : IRepository
{
    public Task<bool> CheckResidentExistsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Resident resident)
    {
        throw new NotImplementedException();
    }
}
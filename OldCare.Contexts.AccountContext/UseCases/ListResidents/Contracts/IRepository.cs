using OldCare.Contexts.AccountContext.Entities;

namespace OldCare.Contexts.AccountContext.UseCases.ListResidents.Contracts;

public interface IRepository
{
    Task<List<Resident>> GetAllResidentsOrderedByName();
}
using OldCare.Contexts.ResidentContext.Entities;

namespace OldCare.Contexts.ResidentContext.UseCases.Modify.Contracts;

public interface IRepository
{
    /// <summary>
    /// Fetch resident data based in global unique identifier.
    /// </summary>
    /// <param name="id">Resident's global unique idenfier</param>
    /// <returns>Return a Entity Resident filled or null</returns>
    Task<Resident?> GetByIdAsync(Guid id);
    /// <summary>
    /// Update resident data
    /// </summary>
    /// <param name="resident"></param>
    /// <returns></returns>
    Task UpdateAsync(Resident resident);
}

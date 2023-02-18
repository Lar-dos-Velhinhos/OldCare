using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Contexts.ResidentContext.UseCases.Modify.Contracts;

public interface IRepository
{
    /// <summary>
    /// Fetch person data based in global unique identifier.
    /// </summary>
    /// <param name="id">Person's global unique identifier</param>
    /// <returns></returns>
    Task<Person?> GetPersonById(Guid id);
    /// <summary>
    /// Fetch resident data based in global unique identifier.
    /// </summary>
    /// <param name="id">Resident's global unique identifier</param>
    /// <returns>Return a Entity Resident filled or null</returns>
    Task<Resident?> GetResidentByIdAsync(Guid id);
    /// <summary>
    /// Update resident data
    /// </summary>
    /// <param name="resident"></param>
    /// <returns></returns>
    Task UpdateAsync(Resident resident);
}

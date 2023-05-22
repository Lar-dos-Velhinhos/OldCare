using OldCare.Contexts.ResidentContext.Entities;

namespace OldCare.Contexts.ResidentContext.UseCases.Delete.Contracts;

public interface IRepository
{
    /// <summary>
    /// Verify if resident exists by resident id
    /// </summary>
    /// <param name="residentId">Resident global unique identifier</param>
    /// <returns>True boolean value if found any resident with requested id and is not deleted</returns>
    Task<bool> CheckResidentExistsByIdAsync(Guid residentId);

    /// <summary>
    /// Fetch resident by your id
    /// </summary>
    /// <param name="residentId">Resident global unique identifier</param>
    /// <returns>Nullable entity of resident type</returns>
    Task<Resident?> GetResidentByIdAsync(Guid residentId);

    /// <summary>
    /// Update resident data asynchronous
    /// </summary>
    /// <param name="resident">Existent resident to update</param>
    /// <returns>Task result status.</returns>
    Task UpdateAsync(Resident resident);
}
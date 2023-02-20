using OldCare.Contexts.ResidentContext.Entities;

namespace OldCare.Contexts.ResidentContext.UseCases.GetDetails.Contracts;

public interface IRepository
{
    /// <summary>
    /// Fetch all resident details 
    /// </summary>
    /// <param name="id">Resident's global unique identifier</param>
    /// <returns></returns>
    Task<Resident?> GetDetailsByIdAsync(Guid id);
}

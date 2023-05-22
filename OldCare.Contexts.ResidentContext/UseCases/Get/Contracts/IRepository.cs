using OldCare.Contexts.ResidentContext.Entities;

namespace OldCare.Contexts.ResidentContext.UseCases.Get.Contracts;

public interface IRepository
{
    /// <summary>
    /// Asynchronous get a list of residents ordered by name
    /// </summary>
    /// <param name="skip">Amount of rows to skip before start catch</param>
    /// <param name="take">Amount of rows that will be taken</param>
    /// <returns></returns>
    Task<List<Resident?>> GetResidentsOrderedByName(int skip, int take);
    
    /// <summary>
    /// Asynchronous get a list of active residents ordered by name
    /// </summary>
    /// <param name="skip">Amount of rows to skip before start catch</param>
    /// <param name="take">Amount of rows that will be taken</param>
    /// <returns></returns>
    Task<List<Resident?>> GetActiveResidentsOrderedByName(int skip, int take);
}
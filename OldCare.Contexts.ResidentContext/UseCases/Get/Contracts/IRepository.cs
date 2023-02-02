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
    Task<List<Resident?>> GetAllResidentsOrderedByName(int skip, int take);
}
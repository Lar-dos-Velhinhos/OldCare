using OldCare.Contexts.ResidentContext.Entities;

namespace OldCare.Contexts.ResidentContext.UseCases.Get.Contracts;

public interface IRepository
{
    Task<List<Resident>> GetAllResidentsOrderedByName();
}
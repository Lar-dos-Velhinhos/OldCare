using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Contexts.ResidentContext.UseCases.Create.Contracts;

public interface IRepository
{
    /// <summary>
    /// Return a bool if exists any resident based in parameters passed.
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="birthDate"></param>
    /// <returns></returns>
    Task<Person?> GetPersonByIdAsync(Guid id);

    /// <summary>
    /// Asynchronous Create a new resident.
    /// </summary>
    /// <param name="resident"></param>
    /// <returns></returns>
    Task CreateAsync(Resident resident);

    /// <summary>
    /// Verify if person exists in Residents using person id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> CheckResidentExistsByPersonIdAsync(Guid id);
}
using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Contexts.PersonContext.UseCases.Modify.Contracts;

public interface IRepository
{
    /// <summary>
    /// Fetch person data based in global unique identifier.
    /// </summary>
    /// <param name="id">Account's global unique identifier</param>
    /// <returns>Return a Entity Person filled or null</returns>
    Task<Person?> GetByIdAsync(Guid id);

    /// <summary>
    /// Update person data
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    Task UpdateAsync(Person? person);
}
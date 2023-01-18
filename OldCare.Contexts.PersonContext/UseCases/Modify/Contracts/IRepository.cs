using OldCare.Contexts.PersonContext.Entities;

namespace OldCare.Contexts.PersonContext.UseCases.Modify.Contracts;

public interface IRepository
{
    /// <summary>
    /// Return a bool value if exists any account based in parameters passed.
    /// </summary>
    /// <param name="id">Account's global unique identifier</param>
    /// <returns></returns>
    Task<bool> CheckAccountExistsByIdAsync(Guid id);

    /// <summary>
    /// Update person data
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    Task UpdateAsync(Person person);
}
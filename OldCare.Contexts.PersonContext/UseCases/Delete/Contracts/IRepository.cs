using OldCare.Contexts.PersonContext.Entities;

namespace OldCare.Contexts.PersonContext.UseCases.Delete.Contracts;

public interface IRepository
{
    /// <summary>
    /// Return a bool value if exists any account based in parameters passed.
    /// </summary>
    /// <param name="id">Account's global unique identifier</param>
    /// <returns></returns>
    Task<bool> CheckAccountExistsByIdAsync(Guid id);
    
    /// <summary>
    /// Asynchronous Get a person by global unique identifier
    /// </summary>
    /// <param name="id">A guid type property</param>
    /// <returns></returns>
    Task<Person> GetByIdAsync(Guid id);

    /// <summary>
    /// Update person data
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    Task UpdateAsync(Person person);
}
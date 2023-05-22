using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.PersonContext.UseCases.Get.Contracts;

public interface IRepository
{
    /// <summary>
    /// Asynchronous Get a person by unique identifier
    /// </summary>
    /// <param name="id">A guid type property</param>
    /// <returns></returns>
    Task<Person> GetByIdAsync(Guid id);

    /// <summary>
    /// Asynchronous Get a person by name
    /// </summary>
    /// <param name="name">string typed name to generate a query</param>
    /// <returns></returns>
    Task<List<Person>> GetByNameAsync(Name name);
    
    /// <summary>
    /// Asynchronous Get a person by name
    /// </summary>
    /// <param name="name">string typed name to generate a query</param>
    /// <returns></returns>
    Task<List<Person?>> GetAll(int skip, int take);
}
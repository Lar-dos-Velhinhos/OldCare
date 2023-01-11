using OldCare.Contexts.PersonContext.Entities;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.PersonContext.UseCases.Create.Contracts;

public interface IRepository
{
    /// <summary>
    /// Return a bool value if exists any account based in parameters passed.
    /// </summary>
    /// <param name="firstName">Person first name</param>
    /// <param name="lastName">Person lastname</param>
    /// <param name="birthDate">Person birthdate</param>
    /// <returns></returns>
    Task<bool> CheckAccountExistsAsync(string firstName, string lastName, DateTime birthDate);
    
    /// <summary>
    /// Asynchronous Create a new person
    /// </summary>
    /// <param name="person">Required a person instance</param>
    /// <returns></returns>
    Task CreateAsync(Person person);
    
    /// <summary>
    /// Delete a existing person
    /// </summary>
    /// <param name="person">Required a person instance</param>
    /// <returns></returns>
    Task Delete(Person person);
    
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
    /// Asynchronous Update person properties
    /// </summary>
    /// <param name="person">Required a person instance</param>
    /// <returns></returns>
    Task UpdateAsync(Person person);
}
using OldCare.Contexts.SharedContext.Entities;

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
    /// Asynchronous Create a new person.
    /// </summary>
    /// <param name="person">Required a person instance</param>
    /// <returns></returns>
    Task CreateAsync(Person? person);
}
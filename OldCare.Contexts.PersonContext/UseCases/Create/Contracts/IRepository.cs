using OldCare.Contexts.PersonContext.Entities;

namespace OldCare.Contexts.PersonContext.UseCases.Create.Contracts;

public interface IRepository
{
    Task CreateAsync(Person person);
    Task<bool> CheckAccountExistsAsync(string firstName, string lastName, DateTime birthDate);
}
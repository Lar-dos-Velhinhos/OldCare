using OldCare.Contexts.AccountContext.Entities;

namespace OldCare.Contexts.AccountContext.UseCases.ChangeEmail.Contracts;

public interface IService
{
    Task SendAccountVerificationEmailAsync(User user);
}
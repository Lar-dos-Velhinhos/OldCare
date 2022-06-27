using OldCare.Contexts.AccountContext.Entities;

namespace OldCare.Contexts.AccountContext.UseCases.VerifyEmail.Contracts;

public interface IService
{
    Task SendAccountVerifiedEmailAsync(User user);
}
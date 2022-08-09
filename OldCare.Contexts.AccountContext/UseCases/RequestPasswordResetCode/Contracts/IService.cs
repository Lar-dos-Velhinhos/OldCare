using OldCare.Contexts.AccountContext.Entities;

namespace OldCare.Contexts.AccountContext.UseCases.RequestPasswordResetCode.Contracts;

public interface IService
{
    Task SendPasswordVerificationCodeAsync(User user, string? returnUrl = null);
}
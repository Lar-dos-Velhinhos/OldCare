using OldCare.Contexts.AccountContext.Entities;

namespace OldCare.Contexts.AccountContext.UseCases.ResendEmailVerificationCode.Contracts;

public interface IService
{
    Task ResendEmailVerificationCodeAsync(User user, string? returnUrl = null);
}
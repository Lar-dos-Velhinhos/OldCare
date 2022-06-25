using OldCare.Contexts.AccountContext.Entities;

namespace OldCare.Contexts.AccountContext.UseCases.Create.Contracts;

public interface IService
{
    Task SendEmailVerificationCodeAsync(Student student, string? returnUrl);
}
namespace OldCare.Services.Google.ReCaptcha.Contracts;

public interface IService
{
    Task<Response?> VerifyAsync(string reCaptchaResponse);
}
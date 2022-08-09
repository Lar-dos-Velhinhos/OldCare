namespace OldCare.Services.Google.ReCaptcha.Exceptions;

public class GoogleCaptchaException : Exception
{
    public GoogleCaptchaException(string message = "Não foi possível validar o ReCatcha.") : base(message)
    {
    }
}
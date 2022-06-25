namespace OldCare.Contexts.SharedContext.ValueObjects.Exceptions;

public class ActivationCodeExpiredException : Exception
{
    public ActivationCodeExpiredException(string message = "Código de ativação expirado") : base(message)
    {
    }

    public static void ThrowIfIsExpired(DateTime expireDate)
    {
        if (expireDate < DateTime.UtcNow)
            throw new ActivationCodeExpiredException();
    }
}
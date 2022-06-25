namespace OldCare.Contexts.SharedContext.ValueObjects.Exceptions;

public class InvalidActivationCodeException : Exception
{
    public InvalidActivationCodeException(string message = "Código de ativação inválido") : base(message)
    {
    }
    
    public static void ThrowIfIsInvalid(string? code, string? challenger)
    {
        if (string.IsNullOrEmpty(code) ||
            string.IsNullOrEmpty(challenger) ||
            code != challenger)
            throw new InvalidActivationCodeException();
    }
}
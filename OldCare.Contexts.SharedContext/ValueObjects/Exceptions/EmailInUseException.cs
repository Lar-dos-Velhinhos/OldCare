namespace OldCare.Contexts.SharedContext.ValueObjects.Exceptions;

public class EmailInUseException : Exception
{
    public EmailInUseException(string message = "Este E-mail já está em uso") : base(message)
    {
    }
}
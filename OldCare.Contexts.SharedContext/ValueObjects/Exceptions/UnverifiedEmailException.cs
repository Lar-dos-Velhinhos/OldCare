namespace OldCare.Contexts.SharedContext.ValueObjects.Exceptions;

public class UnverifiedEmailException : Exception
{
    public UnverifiedEmailException(string message = "E-mail não verificado") : base(message)
    {
    }
}
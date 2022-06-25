namespace OldCare.Contexts.SharedContext.ValueObjects.Exceptions;

public class InvalidPasswordException : Exception
{
    private const string ErrorMessage = "Tente utilizar uma senha mais forte!";

    public InvalidPasswordException(string message = ErrorMessage) : base(message)
    {
    }

    public static void ThrowIfIsInvalid(string text, string errorMessage = ErrorMessage)
    {
        if (string.IsNullOrEmpty(text) ||
            text.Length <= 8)
            throw new InvalidPasswordException(errorMessage);
    }
}
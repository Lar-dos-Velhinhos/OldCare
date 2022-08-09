namespace OldCare.Contexts.SharedContext.ValueObjects.Exceptions;

public class AlreadyVerifiedAccountException : Exception
{
    public AlreadyVerifiedAccountException(string message = "Conta já verificada.") : base(message)
    {
    }
    
    public static void ThrowIfIsVerified(bool isVerified)
    {
        if (isVerified)
            throw new AlreadyVerifiedAccountException();
    }
}
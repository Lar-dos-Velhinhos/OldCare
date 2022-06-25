using System.Text.RegularExpressions;

namespace OldCare.Contexts.SharedContext.ValueObjects.Exceptions;

public class InvalidEmailException : Exception
{
    public InvalidEmailException() : base("E-mail inválido")
    {
    }

    public static void ThrowIfIsInvalid(string? address)
    {
        if (string.IsNullOrEmpty(address))
            throw new InvalidEmailException();

        address = address.Trim();
        
        if (address.Length < 5)
            throw new InvalidEmailException();

        const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        if (!Regex.IsMatch(address, pattern))
            throw new InvalidEmailException();
    }
}
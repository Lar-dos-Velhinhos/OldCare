using OldCare.Contexts.SharedContext.ValueObjects.Exceptions;

namespace OldCare.Contexts.SharedContext.ValueObjects;

public class Name : ValueObject
{
    #region Constructors

    protected Name()
    {
    }

    public Name(string firstName, string lastName)
    {
        InvalidNameException.ThrowIfIsInvalid(firstName, lastName);

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
    }

    #endregion

    #region Properties

    public string FirstName { get; } = string.Empty;
    public string LastName { get; } = string.Empty;

    #endregion
    
    #region Methods

    #endregion

    #region Overloads

    public static implicit operator string(Name name) => $"{name.FirstName} {name.LastName}";

    public static implicit operator Name(string name)
    {
        InvalidNameException.ThrowIfIsInvalid(name);

        name = name.Trim();
        var index = name.IndexOf(" ", StringComparison.Ordinal);

        if (index <= 0)
            throw new InvalidNameException();

        try
        {
            var first = name.Substring(0, index);
            var last = name.Substring(index + 1, name.Length - (index + 1));
            return new Name(first, last);
        }
        catch
        {
            throw new InvalidNameException();
        }
    }

    public override string ToString() => $"{FirstName} {LastName}";

    #endregion
}
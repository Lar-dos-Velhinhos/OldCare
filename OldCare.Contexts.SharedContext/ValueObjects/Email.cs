using OldCare.Contexts.SharedContext.ValueObjects.Exceptions;

namespace OldCare.Contexts.SharedContext.ValueObjects;

public class Email : ValueObject
{
    #region Constructors

    protected Email()
    {
    }

    public Email(string address)
    {
        InvalidEmailException.ThrowIfIsInvalid(address);
        Address = address.ToLower().Trim();
        Verification = new Verification();
    }

    #endregion

    #region Properties

    public string Address { get; private set; } = string.Empty;

    public Verification Verification { get; private set; } = new();

    #endregion

    #region Methods

    public void Expire() => Verification.Invalidate();

    public void GenerateVerificationCode() 
        => Verification = new Verification();

    public void Update(string address)
    {
        InvalidEmailException.ThrowIfIsInvalid(address);
        Address = address.ToLower().Trim();
        Verification = new Verification();
    }

    #endregion

    #region Overloads

    public static implicit operator string(Email email) => email.Address;

    public static implicit operator Email(string address) => new(address);

    public override string ToString() => Address;

    #endregion
}
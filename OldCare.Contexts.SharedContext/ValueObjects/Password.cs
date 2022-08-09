using OldCare.Contexts.SharedContext.ValueObjects.Exceptions;
using SecureIdentity.Password;

namespace OldCare.Contexts.SharedContext.ValueObjects;

public class Password : ValueObject
{
    #region Constructors

    protected Password()
    {
    }

    public Password(string text = "", bool expired = false)
    {
        Text = string.IsNullOrEmpty(text)
            ? PasswordGenerator.Generate()
            : text;

        InvalidPasswordException.ThrowIfIsInvalid(Text);

        HashText(Text);
        Expired = expired;
    }

    #endregion

    #region Properties

    public string Text { get; } = string.Empty;
    public string Hash { get; private set; } = string.Empty;
    public bool Expired { get; private set; }

    #endregion

    #region Methods

    public bool Challenge(string password)
    {
        var result = PasswordHasher.Verify(Hash, password, privateKey: Configuration.Secrets.PrivateKey);

        if (!result)
            throw new InvalidPasswordException("A senha digitada não é válida");

        return result;
    }

    public void Expires() => Expired = true;

    private void HashText(string text) =>
        Hash = PasswordHasher.Hash(text, privateKey: Configuration.Secrets.PrivateKey);

    #endregion

    #region Overloads

    public static implicit operator string(Password password) => password.Hash;

    public static implicit operator Password(string text) => new(text);

    public override string ToString() => Hash;

    #endregion
}
using OldCare.Contexts.SharedContext.ValueObjects.Exceptions;

namespace OldCare.Contexts.SharedContext.ValueObjects;

public class Verification : ValueObject
{
    #region Constructors

    protected Verification()
    {
    }

    public Verification(short len = 8, int expireInMinutes = 120)
    {
        IsVerified = false;
        Code = GenerateVerificationCode(len);
        CodeExpireDate = DateTime.UtcNow.AddMinutes(expireInMinutes);
    }

    #endregion

    #region Properties

    public bool IsVerified { get; private set; }
    public string Code { get; } = string.Empty;
    public DateTime CodeExpireDate { get; private set; } = DateTime.UtcNow.AddHours(2);

    #endregion

    #region Methods

    public bool IsValid()
    {
        if (CodeExpireDate > DateTime.UtcNow)
            return true;

        return false;
    }

    public void Verify(string verificationCode)
    {
        AlreadyVerifiedAccountException.ThrowIfIsVerified(IsVerified);
        InvalidActivationCodeException.ThrowIfIsInvalid(Code, verificationCode);
        ActivationCodeExpiredException.ThrowIfIsExpired(CodeExpireDate);

        IsVerified = true;
    }

    public void Invalidate() => IsVerified = false;

    private static string GenerateVerificationCode(short len = 8) => Guid.NewGuid().ToString().ToUpper()[..len];

    #endregion

    #region Overloads

    public static implicit operator string(Verification verification) => verification.Code;

    #endregion
}
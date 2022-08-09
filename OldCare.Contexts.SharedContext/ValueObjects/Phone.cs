using OldCare.Contexts.SharedContext.Extensions;

namespace OldCare.Contexts.SharedContext.ValueObjects;

public class Phone : ValueObject
{
    #region Constructors

    protected Phone()
    {
    }

    public Phone(int countryCode, int regionCode, string number)
    {
        CountryCode = countryCode;
        RegionCode = regionCode;
        Number = number.ToNumbersOnly();
        FullNumber = $"{countryCode}{regionCode}{number}";
        Verification = new Verification(6, 5);
    }

    #endregion

    #region Properties

    public int CountryCode { get; }
    public int RegionCode { get; }
    public string Number { get; } = string.Empty;
    public string? FullNumber { get; set; } = string.Empty;
    public Verification Verification { get; private set; } = null!;

    #endregion

    #region Methods

    public void GenerateVerificationCode()
    {
        Verification verification = new(6, 5);
        Verification = verification;
    }

    #endregion

    #region Overloads

    public static implicit operator string(Phone? phone) => phone?.FullNumber ?? string.Empty;

    public static implicit operator Phone(string phone)
    {
        try
        {
            return new Phone(
                int.Parse(phone.Substring(0, 2)),
                int.Parse(phone.Substring(2, 2)),
                phone.Substring(4, phone.Length - 4)
            );
        }
        catch
        {
            return new Phone(0, 0, "");
        }
    }

    public override string ToString() => FullNumber ?? string.Empty;

    #endregion
}
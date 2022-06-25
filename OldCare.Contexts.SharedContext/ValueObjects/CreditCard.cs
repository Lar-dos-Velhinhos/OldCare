using OldCare.Contexts.SharedContext.Extensions;

namespace OldCare.Contexts.SharedContext.ValueObjects;

public class CreditCard : ValueObject
{
    public CreditCard(
        string number,
        string holder,
        DateTime expireDate,
        int cvv)
    {
        Number = number.ToNumbersOnly();
        Holder = holder.Trim().ToUpper();
        ExpireDate = expireDate;
        Cvv = cvv;
    }

    public string Number { get; }
    public string Holder { get; }
    public DateTime ExpireDate { get; }
    public int Cvv { get; }
}
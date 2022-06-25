using OldCare.Contexts.SharedContext.Extensions;

namespace OldCare.Contexts.SharedContext.ValueObjects;

public class Address : ValueObject
{
    protected Address()
    {
    }

    public Address(
        string zipCode,
        string street,
        string number,
        string district,
        string city,
        string state,
        string country = "BR",
        string? complement = null,
        string? code = null,
        string? notes = null)
    {
        ZipCode = zipCode.ToNumbersOnly();
        Street = street;
        Number = number;
        District = district;
        City = city;
        State = state;
        Country = country;
        Complement = complement;
        Code = code?.ToNumbersOnly();;
        Notes = notes;
    }

    public string ZipCode { get; } = string.Empty;
    public string Street { get; } = string.Empty;
    public string Number { get; } = string.Empty;
    public string? Complement { get; } = string.Empty;
    public string District { get; } = string.Empty;
    public string City { get; } = string.Empty;
    public string State { get; } = string.Empty;
    public string Country { get; } = string.Empty;
    public string? Code { get; } = string.Empty;
    public string? Notes { get; } = string.Empty;
}
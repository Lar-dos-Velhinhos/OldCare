using OldCare.Contexts.SharedContext.Extensions;

namespace OldCare.Contexts.SharedContext.ValueObjects;

public class Address : ValueObject
{
    protected Address()
    {
    }

    public Address(
        string city,
        string district,
        string number,
        string state,
        string street,
        string zipCode,
        string? code = null,
        string? complement = null,
        string country = "BR",
        string? notes = null)
    {
        City = city;
        District = district;
        Number = number;
        State = state;
        Street = street;
        ZipCode = zipCode.ToNumbersOnly();
        Code = code?.ToNumbersOnly();
        Complement = complement;
        Country = country;
        Notes = notes;
    }

    public string City { get; } = string.Empty;
    public string District { get; } = string.Empty;
    public string Number { get; } = string.Empty;
    public string State { get; } = string.Empty;
    public string Street { get; } = string.Empty;
    public string ZipCode { get; } = string.Empty;
    public string? Code { get; } = string.Empty;
    public string? Complement { get; } = string.Empty;
    public string Country { get; } = string.Empty;
    public string? Notes { get; } = string.Empty;
}
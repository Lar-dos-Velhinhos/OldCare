using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.UseCases.Contracts;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.SharedContext.Entities;

/// <summary>
/// A entity to aggregate Person data
/// </summary>
public class Person : Entity, IAggregateRoot
{
    #region Constructors

    /// <summary>
    /// Create a new instance of Person with default configuration
    /// </summary>
    public Person() => Tracker = new Tracker("Criação do cadastro da pessoa");
    
    /// <summary>
    /// Create a new instance of Person with personalized configuration
    /// </summary>
    /// <param name="address">Person detailed address (value object)</param>
    /// <param name="birthDate">Person birthdate</param>
    /// <param name="citizenship">Person citizenship</param>
    /// <param name="documents">Wait an list of Person Documents</param>
    /// <param name="gender">Person Gender</param>
    /// <param name="name">Person Name (value object)</param>
    /// <param name="obs">Person observations</param>
    /// <param name="phone">Person full phone number (value object)</param>
    /// <param name="photo">Person photo url slug</param>
    /// <exception cref="ArgumentNullException"></exception>
    public Person(
        Address address,
        DateTime? birthDate,
        string? citizenship,
        List<Document>? documents,
        EGender gender,
        Name name,
        string? obs,
        Phone? phone,
        string? photo)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
        BirthDate = birthDate;
        Citizenship = citizenship;
        Documents = documents;
        Gender = gender;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Obs = obs;
        Phone = phone;
        Photo = photo;
        Tracker = new Tracker("Criação do cadastro da pessoa");
    }

    #endregion

    #region Public Properties

    public Address Address { get; private set; } = null!;
    public DateTime? BirthDate { get; private set; }
    public string? Citizenship { get; private set; } = string.Empty;
    public List<Document>? Documents { get; private set; }
    public EGender Gender { get; private set; }
    public bool IsDeleted { get; set; }
    public Name Name { get; private set; }
    public string Nationality { get; set; } = string.Empty;
    public string? Obs { get; private set; } = string.Empty;
    public Phone? Phone { get; private set; }
    public string? Photo { get; private set; } = string.Empty;
    public string? FatherName { get; private set; } = string.Empty;
    public string? MotherName { get; private set; } = string.Empty;
    public Tracker Tracker { get; } = null!;
    [NotMapped]
    public int Age { get; set; }

    #endregion

    #region Methods

    public void AddDocuments(List<Document> documents)
        => Documents = documents;

    public void ChangeDocuments(List<Document?> documents)
    {
        try
        {
            Documents = documents;
        }
        catch
        {
            throw new InvalidDataException("Não foi possível salvar os documentos.");
        }
    }
    
    public void ChangeInformation(
        DateTime? birthDate,
        string citizenship,
        EGender gender,
        string nationality,
        string? obs)
    {
        BirthDate = birthDate;
        Citizenship = citizenship;
        Gender = gender;
        Nationality = nationality;
        Obs = obs;

        Tracker.Update("Informações atualizadas");
    }    
    
    public void ModifyAddress(Address address) => Address = address;    
    public void ChangeName(string firstName, string lastName)
        => Name = new Name(firstName, lastName);

    public void ChangePhone(Phone phone)
    {
        Phone = phone;
        Tracker.Update("Número de telefone modificado.");
    }

    public void ChangePhoto(string path)
        => Photo = path;

    public void Delete()
    {
        IsDeleted = true;
        Tracker.Update("Pessoa deletada.");
    }

    public void GeneratePhoneVerificationCode()
    {
        Phone?.GenerateVerificationCode();
        Tracker.Update("Código de verificação de telefone recriado");
    }
    
    public int GetAge()
    {
        int age = DateTime.UtcNow.Year - BirthDate.Value.Year;
        if (DateTime.UtcNow.DayOfYear < BirthDate.Value.DayOfYear)
            age = age - 1;

        return age;
    }

    public void ChangeParents(string? fatherName, string? motherName)
    {
        FatherName = fatherName; 
        MotherName = motherName;
    }

    public void VerifyPhone(string code)
    {
        Phone?.Verification.Verify(code);
        Tracker.Update("Telefone verificado");
    }

    #endregion
    
    #region Overloads

    public override string ToString() => Name;

    #endregion
}
using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.UseCases.Contracts;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.PersonContext.Entities;

public class Person : Entity, IAggregateRoot
{
    #region Constructors
    
    public Person()
    {
    }

    public Person(
        Address address,
        DateTime? birthDate,
        string? citizenship,
        List<Document>? documents,
        bool gender,
        Name name,
        string? obs,
        Phone? phone,
        string? photo,
        Tracker tracker)
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
        Tracker = tracker ?? throw new ArgumentNullException(nameof(tracker));
    }
    
    // public Person(
    //     Address address,
    //     int zipCode,
    //     string street,
    //     string number,
    //     string district,
    //     string city,
    //     string state,
    //     string country,
    //     string complement,
    //     string code,
    //     string notes,
    //     string firstName,
    //     string lastName,
    //     string fullNumber,
    //     string isVerified,
    //     string code,
    //     DateTime? codeExpireDate,
    //     string citizenship,
    //     List<Document>? documents,
    //     bool gender,
    //     string obs,
    //     DateTime birthDate,
    //     DateTime createdAt,
    //     DateTime updatedAt,
    //     string notes,
    //     string photo)
    // {
    //     Address = address ?? throw new ArgumentNullException(nameof(address));
    //     BirthDate = birthDate;
    //     Citizenship = citizenship;
    //     Documents = documents;
    //     Gender = gender;
    //     Name = name ?? throw new ArgumentNullException(nameof(name));
    //     Obs = obs;
    //     Phone = phone;
    //     Photo = photo;
    //     Tracker = tracker ?? throw new ArgumentNullException(nameof(tracker));
    // }

    #endregion

    #region Properties

    public Address Address { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public string? Citizenship { get; private set; }
    public List<Document>? Documents { get; private set; }
    public bool Gender { get; private set; }
    public Name Name { get; private set; }
    public string? Obs { get; private set; }
    public Phone? Phone { get; private set; }
    public string? Photo { get; private set; }
    public Tracker Tracker { get; }
    [NotMapped]
    public int Age { get; set; }

    #endregion

    #region Methods

    public void ChangePhone(Phone phone)
    {
        Phone = phone;
        Tracker.Update("Número de telefone modificado.");
    }

    public void ChangeDocuments(List<Document> documents)
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
        string firstName,
        string lastName,
        DateTime? birthDate,
        string obs)
    {
        Name = new Name(firstName, lastName);
        BirthDate = birthDate;
        Obs = obs;

        Tracker.Update("Informações atualizadas");
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
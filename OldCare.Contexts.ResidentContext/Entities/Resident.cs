using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.UseCases.Contracts;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.ResidentContext.Entities;

/// <summary>
/// A entity to agregate Resident data
/// </summary>
public class Resident : Entity, IAggregateRoot
{
    #region Constructors

    /// <summary>
    /// Create a new instance of Resident with default configuration
    /// </summary>
    public Resident()
    {
        Occurrences = new();
        Tracker = new Tracker("Criação do cadastro do residente");
    }

    /// <summary>
    /// Create a new instance of Resident with default configuration
    /// </summary>
    /// <param name="person">Entity required to initialize</param>
    public Resident(Person? person)
    {
        Person = person;
        Occurrences = new();
        Tracker = new Tracker("Criação do cadastro do residente");
    }

    /// <summary>
    /// Create a new instance of Resident with personalized configuration
    /// </summary>
    /// <param name="person">Resident Person data</param>
    /// <param name="admissionDate">Resident admission Date</param>
    /// <param name="bedroom">Resident Bedroom data</param>
    /// <param name="educationLevel">Resident education level</param>
    /// <param name="departureDate">Resident departure date</param>
    /// <param name="maritalStatus">Resident marital status</param>
    /// <param name="mobility">Resident mobility</param>
    /// <param name="occurrences">Wait an list of Resident occurrences</param>
    /// <param name="sus">Resident SUS card number</param>
    /// <param name="voterRegCardNumber">Resident voter registrtion number</param>
    public Resident(Person? person,
        DateTime admissionDate,
        Bedroom bedroom,
        EEducationLevel educationLevel,
        DateTime? departureDate,
        EMaritalStatus maritalStatus,
        EMobility mobility,
        List<Occurrence?> occurrences,
        long sus,
        long voterRegCardNumber)
    {
        Person = person;
        AdmissionDate = admissionDate;
        Bedroom = bedroom;
        EducationLevel = educationLevel;
        DepartureDate = departureDate;
        MaritalStatus = maritalStatus;
        Mobility = mobility;
        Occurrences = occurrences;
        SUS = sus;
        VoterRegCardNumber = voterRegCardNumber;
        Tracker = new Tracker("Criação do cadastro de residente");
    }

    #endregion
    
    #region Properties

    public Person? Person { get; init; } = null!;
    public DateTime AdmissionDate { get; private set; }
    public Bedroom? Bedroom { get; private set; }
    public EEducationLevel EducationLevel { get; private set; }
    public DateTime? DepartureDate { get; private set; }
    public string HealthInsurance { get; private set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public EMaritalStatus MaritalStatus { get; private set; }
    public EMobility Mobility { get; private set; }
    public string? Note { get; set; } = string.Empty;
    public List<Occurrence?> Occurrences { get; private set; }
    public string? Profession { get; private set; } = string.Empty;
    public long SUS { get; set; }
    public long VoterRegCardNumber { get; private set; }
    public Tracker Tracker { get; set; } = null!;

    #endregion

    #region Methods

    public void ModifyBedroom(Bedroom bedroom) => Bedroom = bedroom;
    
    public void AddOccurrences(List<Occurrence> occurrences)
        => Occurrences = occurrences;

    public void ChangeOccurrences(List<Occurrence?> occurrences)
    {
        try
        {
            Occurrences = occurrences;
        }
        catch
        {
            throw new InvalidDataException("Não foi possível salvar as ocorrências.");
        }
    }

    public void Delete()
    {
        IsDeleted = true;
        Tracker.Update("Residente deletado.");
    }

    public void ChangeInformation(
        DateTime admissionDate,
        EEducationLevel educationLevel,
        DateTime? departureDate,
        string healthInsurance,
        bool isDeleted,
        EMaritalStatus maritalStatus,
        EMobility mobility,
        string note,
        string profession,
        long sus,
        long voterRegCardNumber)
    {
        AdmissionDate = admissionDate;
        EducationLevel = educationLevel;
        DepartureDate = departureDate;
        HealthInsurance = healthInsurance;
        IsDeleted = isDeleted;
        MaritalStatus = maritalStatus;
        Mobility = mobility;
        Note = note;
        Profession = profession;
        SUS = sus;
        VoterRegCardNumber = voterRegCardNumber;
        
        Tracker.Update("Informações do residente atualizadas");
    }

    #endregion
}
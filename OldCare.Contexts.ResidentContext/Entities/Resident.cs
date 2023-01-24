using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.ResidentContext.Entities;

public class Resident : Entity
{
    #region Properties

    public Person Person { get; private set; } = null!;
    public DateTime AdmissionDate { get; private set; }
    public Bedroom Bedroom { get; private set; } = null!;
    public EEducationLevel EducationLevel { get; private set; }
    public DateTime? DepartureDate { get; private set; }
    public string HealthInsurance { get; private set; } = string.Empty;
    public EMaritalStatus MaritalStatus { get; private set; }
    public EMobility Mobility { get; private set; }
    public string Note { get; set; } = string.Empty;
    public List<Occurrence> Occurrences { get; private set; }
    public string Profession { get; private set; } = string.Empty;
    public long SUS { get; set; }
    public long VoterRegCardNumber { get; private set; }

    #endregion
    
    #region Methods

    #endregion
}
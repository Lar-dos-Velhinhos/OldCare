using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Entities;
using OldCare.Core.Enums;


[Table("Resident")]
public class Resident : Entity
{
    public Person Person { get; set; } = null!;
    public Bedroom? Bedroom { get; set; } = null;
    public DateTime AdmissionDate { get; set; }
    public DateTime? DepartureDate { get; set; }
    public string Father { get; set; } = string.Empty;
    public string HealthInsurance { get; set; } = string.Empty;
    public EMaritalStatus MaritalStatus { get; set; }
    public EMobility Mobility { get; set; }
    public string Mother { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public string Profession { get; set; } = string.Empty;
    public EEducationLevel EducationLevel { get; set; }
    public long SUS { get; set; }
    public long VoterRegCardNumber { get; set; }
}


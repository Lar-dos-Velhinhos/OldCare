using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Enums;

namespace OldCare.Core.Entities;

[Table("Resident")]
public class Resident : Entity
{
    public Person Person { get; set; }
    public Bedroom Bedroom { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime? DepartureDate { get; set; }
    public string Father { get; set; }
    public string HealthInsurance { get; set; }
    public EMaritalStatus MaritalStatus { get; set; }
    public EMobility Mobility { get; set; }
    public string Mother { get; set; }
    public string Note { get; set; }
    public string Profession { get; set; }
    public EEducationLevel EducationLevel { get; set; }
    public long SUS { get; set; }
    public long VoterRegCardNumber { get; set; }
}
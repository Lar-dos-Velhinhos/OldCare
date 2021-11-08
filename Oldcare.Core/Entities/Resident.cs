using System.ComponentModel.DataAnnotations.Schema;


[Table("Resident")]
public class Resident : Entity
{
    public Person Person { get; set; }
    public Bedroom Bedroom { get; set; }
    public DateOnly AdmissionDate { get; set; }
    public DateOnly? DepartureDate { get; set; }
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


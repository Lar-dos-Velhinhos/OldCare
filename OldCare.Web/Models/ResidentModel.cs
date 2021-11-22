namespace OldCare.Web.Models;

[Table("Resident")]
public class ResidentModel : Entity
{
    public ResidentModel(EditResidentViewModel model)
    {
        Id = Guid.NewGuid();
        PersonId = model.PersonId;
        BedroomId = model.BedroomId;
        AdmissionDate = model.AdmissionDate;
        DepartureDate = model.DepartureDate;
        Father = model.Father;
        HealthInsurance = model.HealthInsurance;
        MaritalStatus = model.MaritalStatus;
        Mobility = model.Mobility;
        Mother = model.Mother;
        Note = model.Note;
        Profession = model.Profession;
        EducationLevel = model.EducationLevel;
        SUS = model.SUS;
        VoterRegCardNumber = model.VoterRegCardNumber;
    }

    public Guid PersonId { get; set; }
    public virtual Person? Person { get; set; }
    public Guid BedroomId { get; set; }
    public virtual Bedroom? Bedroom { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime? DepartureDate { get; set; }
    public string? Father { get; set; }
    public string? HealthInsurance { get; set; }
    public EMaritalStatus MaritalStatus { get; set; }
    public EMobility Mobility { get; set; }
    public string? Mother { get; set; }
    public string? Note { get; set; }
    public string? Profession { get; set; }
    public EEducationLevel EducationLevel { get; set; }
    public long SUS { get; set; }
    public long VoterRegCardNumber { get; set; }
}
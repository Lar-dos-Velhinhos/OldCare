namespace OldCare.Web.Models;

[Table("Medication")]
public class Medication : Entity
{
    public PrescriptionItem? PrescriptionItem { get; set; }
    public string? COREN { get; set; }
    public DateTime? MedicationDate { get; set; }
    public string? Note { get; set; }
}
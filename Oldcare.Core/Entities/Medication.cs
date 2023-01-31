using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Entities;

[Table("Medication")]
public class Medication : Entity
{
    public PrescriptionItem PrescriptionItem { get; set; } = null!;
    public string COREN { get; set; } = string.Empty;
    public DateTime MedicationDate { get; set; }
    public string Note { get; set; } = string.Empty;
}


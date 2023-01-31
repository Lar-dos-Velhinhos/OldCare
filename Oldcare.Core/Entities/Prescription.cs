using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Entities;

[Table("Prescription")]
public class Prescription : Entity
{
    public Resident Resident { get; set; } = null!;
    public string PrescriptionAuthor { get; set; } = string.Empty;
    public DateTime PrescriptionDate { get; set; }
}


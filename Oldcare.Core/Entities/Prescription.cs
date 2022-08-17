using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Entities;

[Table("Prescription")]
public class Prescription : Entity
{
    public Resident Resident { get; set; }
    public string PrescriptionAuthor { get; set; }
    public DateTime PrescriptionDate { get; set; }
}


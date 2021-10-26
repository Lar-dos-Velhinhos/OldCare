using System.ComponentModel.DataAnnotations.Schema

[Table("Prescription")]
public class Prescription : Entity
{
    public Resident Resident { get; set; }
    public string PrescriptionAuthor { get; set; }
    public DateTime PrescriptionDate { get; set; }
}


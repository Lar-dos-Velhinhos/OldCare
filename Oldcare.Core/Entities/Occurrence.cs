using System.ComponentModel.DataAnnotations.Schema;

[Table("Occurrence")]
public class Occurrence : Entity
{
    public Resident Resident { get; set; }
    public string Description { get; set; }
    public DateTime OccurrenceDate { get; set; }
    public EOccurrenceType OccurrenceType { get; set; }
}


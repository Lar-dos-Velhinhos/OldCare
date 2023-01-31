using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Entities;
using OldCare.Core.Enums;

[Table("Occurrence")]
public class Occurrence : Entity
{
    public Resident Resident { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public DateTime OccurrenceDate { get; set; }
    public EOccurrenceType OccurrenceType { get; set; }
}


using System.ComponentModel.DataAnnotations.Schema;
using Oldcare.Core.Enums;

namespace Oldcare.Core.Entities;

[Table("Occurrence")]
public class Occurrence : Entity
{
    public Resident Resident { get; set; }
    public string Description { get; set; }
    public DateTime OccurrenceDate { get; set; }
    public EOccurrenceType OccurrenceType { get; set; }
}
namespace OldCare.Web.Models;


[Table("Occurrence")]
public class Occurrence : Entity
{
    public Guid ResidentId { get; set; }
    public virtual ResidentModel? Resident { get; set; }
    public string? Description { get; set; }
    public DateTime OccurrenceDate { get; set; }
    public EOccurrenceType OccurrenceType { get; set; }
}
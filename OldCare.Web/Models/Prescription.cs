namespace OldCare.Web.Models;

[Table("Prescription")]
public class Prescription : Entity
{
    public Guid ResidentId { get; set; }
    public virtual Resident? Resident { get; set; }
    public Guid AuthorId { get; set; }
    public virtual Person? Author { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime PrescriptionDate { get; set; }
}
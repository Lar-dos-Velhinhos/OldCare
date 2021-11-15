namespace OldCare.Web.Models;

[Table("PrescriptionItem")]
public class PrescriptionItem : Entity
{
    public Guid PrescriptionId { get; set; }
    public virtual Prescription? Prescription { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public double Amount { get; set; }
    public int Frequency { get; set; }
    public EInterval Interval { get; set; }
    public string? Note { get; set; }
    public string? Presentation { get; set; }
}
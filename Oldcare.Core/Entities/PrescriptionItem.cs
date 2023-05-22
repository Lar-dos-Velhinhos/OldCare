using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Entities;
using OldCare.Core.Enums;

[Table("PrescriptionItem")]
public class PrescriptionItem : Entity
{
    public Prescription Prescription { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public double Amount { get; set; }
    public int Frequency { get; set; }
    public EInterval Interval { get; set; }
    public string Note { get; set; } = string.Empty;
    public string Presentation { get; set; } = string.Empty;
}


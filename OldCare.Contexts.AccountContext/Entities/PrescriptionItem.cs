using OldCare.Contexts.SharedContext.Enums;

namespace OldCare.Contexts.AccountContext.Entities;

public class PrescriptionItem : SharedContext.Entities.Entity
{
    public Prescription Prescription { get; set; }
    public Product Product { get; set; }
    public double Amount { get; set; }
    public int Frequency { get; set; }
    public EInterval Interval { get; set; }
    public string Note { get; set; }
    public string Presentation { get; set; }
}
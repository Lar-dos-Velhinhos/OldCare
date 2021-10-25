namespace Oldcare.Core.Entities;

public class PrescriptionItem : Entity
{
    public Prescription Prescription { get; set; }
    public Product Product { get; set; }
    public double Amount { get; set; }
    public int Frequency { get; set; }
    public EInterval Interval { get; set; }
    public string Note { get; set; }
    public string Presentation { get; set; }
}


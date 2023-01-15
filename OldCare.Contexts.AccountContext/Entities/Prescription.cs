namespace OldCare.Contexts.AccountContext.Entities;

public class Prescription : SharedContext.Entities.Entity
{
    public Resident Resident { get; set; }
    public string PrescriptionAuthor { get; set; }
    public DateTime PrescriptionDate { get; set; }
}
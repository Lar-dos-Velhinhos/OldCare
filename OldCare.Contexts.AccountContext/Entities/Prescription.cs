using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.SharedContext.Entities;

public class Prescription : Entity
{
    public Resident Resident { get; set; }
    public string PrescriptionAuthor { get; set; }
    public DateTime PrescriptionDate { get; set; }
}


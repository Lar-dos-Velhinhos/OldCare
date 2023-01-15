namespace OldCare.Contexts.AccountContext.Entities;

public class ResidentResponsible : SharedContext.Entities.Entity
{
    public Resident Resident { get; set; }
    public Responsible Responsible { get; set; }
    public bool Forwarder { get; set; }
    public DateTime EndDate { get; set; }
    public bool Primary { get; set; }
    public DateTime StartDate { get; set; }
}
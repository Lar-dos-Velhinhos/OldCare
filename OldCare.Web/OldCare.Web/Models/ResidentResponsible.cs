namespace OldCare.Web.Models;

[Table("ResidentResponsible")]
public class ResidentResponsible : Entity
{
    public Guid ResidentId { get; set; }
    public Guid ResponsibleId { get; set; }
    public bool Forwarder { get; set; }
    public DateTime EndDate { get; set; }
    public bool Primary { get; set; }
    public DateTime StartDate { get; set; }
}
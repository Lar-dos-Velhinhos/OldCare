namespace OldCare.Web.Models;

[Table("Responsible")]
public class Responsible : Entity
{
    public virtual Person? Person { get; set; }
    public virtual Resident? Resident { get; set; }
    public DateTime EndDate { get; set; }
    public bool Forwarder { get; set; }
    public bool Primary { get; set; }
    public DateTime StartDate { get; set; }
    public EKinship Kinship { get; set; }
}
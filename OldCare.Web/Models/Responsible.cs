namespace OldCare.Web.Models;

[Table("Responsible")]
public class Responsible : Entity
{
    public Guid PersonId { get; set; }
    public virtual Person? Person { get; set; }
    public EKinship Kinship { get; set; }
    public long PhoneNumber { get; set; }
}
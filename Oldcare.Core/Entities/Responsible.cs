using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Enums;

namespace OldCare.Core.Entities;

[Table("Responsible")]
public class Responsible : Entity
{
    public Person Person { get; set; }

    public EKinship Kinship { get; set; }
    public long PhoneNumber { get; set; }
}
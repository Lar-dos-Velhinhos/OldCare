using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Entities;
using OldCare.Core.Enums;

[Table("Responsible")]
public class Responsible : Entity
{
    public Person Person { get; set; } = null!;

    public EKinship Kinship { get; set; }
    public long PhoneNumber { get; set; }
}


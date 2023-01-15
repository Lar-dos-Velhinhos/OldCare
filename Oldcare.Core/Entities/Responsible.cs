using System.ComponentModel.DataAnnotations.Schema;
using Oldcare.Core.Enums;

namespace Oldcare.Core.Entities;

[Table("Responsible")]
public class Responsible : Entity
{
    public Person Person { get; set; }

    public EKinship Kinship { get; set; }
    public long PhoneNumber { get; set; }
}
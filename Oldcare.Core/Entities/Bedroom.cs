using System.ComponentModel.DataAnnotations.Schema;

namespace Oldcare.Core.Entities;

[Table("Bedroom")]
public class Bedroom : Entity
{
    public int Capacity { get; set; }
    public bool Gender { get; set; }
    public int Number { get; set; }
}
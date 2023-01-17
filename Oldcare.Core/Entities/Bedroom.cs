using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Entities;

[Table("Bedroom")]
public class Bedroom : Entity
{
    public int Capacity { get; set; }
    public bool Gender { get; set; }
    public int Number { get; set; }
}


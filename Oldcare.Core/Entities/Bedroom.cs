using System.ComponentModel.DataAnnotations.Schema;

[Table("Bedroom")]
public class Bedroom : Entity
{
    public int Capacity { get; set; }
    public bool Gender { get; set; }
    public int Number { get; set; }
}


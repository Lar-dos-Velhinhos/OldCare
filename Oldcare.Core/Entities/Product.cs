using System.ComponentModel.DataAnnotations.Schema;

[Table("Product")]
public class Product : Entity
{
    public string Name { get; set; }
    public string UnitOfMeasurement { get; set; }
}


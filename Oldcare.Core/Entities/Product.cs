using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Entities;

[Table("Product")]
public class Product : Entity
{
    public string Name { get; set; } = null!;
    public string UnitOfMeasurement { get; set; } = string.Empty;
}


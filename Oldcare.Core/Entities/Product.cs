using System.ComponentModel.DataAnnotations.Schema;

namespace OldCare.Core.Entities;

[Table("Product")]
public class Product : Entity
{
    public string Name { get; set; }
    public string UnitOfMeasurement { get; set; }
}
namespace OldCare.Web.Models;

[Table("Product")]
public class Product : Entity
{
    public Product(string name, string unitOfMeasurement)
    {
        Name = name;
        UnitOfMeasurement = unitOfMeasurement;
    }

    public string Name { get; set; }
    public string UnitOfMeasurement { get; set; }
}
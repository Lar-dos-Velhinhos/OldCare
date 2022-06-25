namespace OldCare.Web.Models;

[Table("Product")]
public class Product : Entity
{
    [Display(Name ="Nome")]
    public string Name { get; set; }

    [Display(Name ="Unidade de Medida")]
    public string UnitOfMeasurement { get; set; }
}
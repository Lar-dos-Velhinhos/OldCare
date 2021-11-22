namespace OldCare.Web.Models;

[Table("Bedroom")]
public class Bedroom : Entity
{
    public Bedroom(int capacity, bool gender, int number)
    {
        Capacity = capacity;
        Gender = gender;
        Number = number;
    }
    [Display(Name ="Capacidade")]
    public int Capacity { get; set; }
    [Display(Name = "Gênero")]
    public bool Gender { get; set; }
    [Display(Name = "Número")]
    public int Number { get; set; }
}
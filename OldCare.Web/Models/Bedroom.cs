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

    public int Capacity { get; set; }
    public bool Gender { get; set; }
    public int Number { get; set; }
}
namespace OldCare.Web.Models;

[Table("Person")]
public class Person : Entity
{
    public Person(string address, DateTime? birthDate, string? citizenship, int? cEP, string city, long? cPF, string district, bool? gender, string name, string? note, string? photo, long? rG, string? uF)
    {
        Address = address;
        BirthDate = birthDate;
        Citizenship = citizenship;
        CEP = cEP;
        City = city;
        CPF = cPF;
        District = district;
        Gender = gender;
        Name = name;
        Note = note;
        Photo = photo;
        RG = rG;
        UF = uF;
    }

    public string Address { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Citizenship { get; set; }
    public int? CEP { get; set; }
    public string City { get; set; }
    public long? CPF { get; set; }
    public string District { get; set; }
    public bool? Gender { get; set; }
    public string Name { get; set; }
    public string? Note { get; set; }
    public string? Photo { get; set; }
    public long? RG { get; set; }
    public string? UF { get; set; }
}
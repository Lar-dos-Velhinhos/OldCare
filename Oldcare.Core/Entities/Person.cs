using System.ComponentModel.DataAnnotations.Schema;

namespace OldCare.Core.Entities;

[Table("Person")]
public class Person : Entity
{
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
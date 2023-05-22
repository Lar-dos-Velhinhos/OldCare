using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Contexts.SharedContext.ValueObjects;
using OldCare.Core.Entities;

[Table("Person")]
public class Person : Entity
{
    public Address Address { get; set; } = null!;
    public DateTime? BirthDate { get; set; }
    public string Citizenship { get; set; } = string.Empty;
    public int? CEP { get; set; }
    public string City { get; set; } = string.Empty;
    public long? CPF { get; set; }
    public string District { get; set; } = string.Empty;
    public bool? Gender { get; set; }
    public string Name { get; set; } = null!;
    public string Note { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
    public long? RG { get; set; }
    public string? UF { get; set; }
}


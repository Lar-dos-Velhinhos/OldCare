 using System.ComponentModel;

namespace OldCare.Web.Models;

[Table("Person")]
public class Person : Entity
{
    [DisplayName("Endereço")]
    public string Address { get; set; }
    [DisplayName("Número")]
    public string AddressNumber { get; set; }
    [DisplayName("Data de Nascimento")]
    public DateTime? BirthDate { get; set; }
    [DisplayName("Naturalidade")]
    public string? Citizenship { get; set; }
    public int? CEP { get; set; }
    [DisplayName("Cidade")]
    public string City { get; set; }
    public long? CPF { get; set; }
    [DisplayName("Bairro")]
    public string District { get; set; }
    [DisplayName("Gênero")]
    public bool Gender { get; set; }
    [DisplayName("Nome")]
    public string Name { get; set; }
    [DisplayName("Observação")]
    public string? Note { get; set; }
    [DisplayName("Telefone")]
    public string? PhoneNumber { get; set; }
    public string? Photo { get; set; }
    public string? RG { get; set; }
    [DisplayName("Estado")]
    public string? UF { get; set; }
}
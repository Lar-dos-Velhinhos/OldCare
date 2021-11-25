namespace OldCare.Web.Models;

[Table("Person")]
public class Person : Entity
{
    [Display(Name = "Endereço")]
    public string Address { get; set; }

    [Display(Name = "Número")]
    public string AddressNumber { get; set; }

    [Display(Name = "Data de Nascimento")]
    public DateTime? BirthDate { get; set; }

    [Display(Name = "Naturalidade")]
    public string? Citizenship { get; set; }

    [Display(Name = "CEP")]
    public int? CEP { get; set; }

    [Display(Name = "Cidade")]
    public string City { get; set; }

    [Display(Name = "CPF")]
    public string? CPF { get; set; }

    [Display(Name = "Bairro")]
    public string District { get; set; }

    [Display(Name = "Gênero")]
    public EGender Gender { get; set; }

    [Display(Name = "Nome")]
    public string Name { get; set; }

    [Display(Name = "Observação")]
    public string? Note { get; set; }

    [Display(Name = "Telefone")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Foto")]
    public string? Photo { get; set; }

    [Display(Name = "RG")]
    public string? RG { get; set; }

    [Display(Name = "Estado")]
    public string? UF { get; set; }
}
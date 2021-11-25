namespace OldCare.Web.Models;

[Table("Emploee")]
public class Emploee : Entity
{
    [Display(Name = "Pessoa")]
    public Guid PersonId { get; set; }

    public virtual Person? Person { get; set; }

    [Display(Name = "Data de Contratação")]
    public DateTime HiringDate { get; set; }

    [Display(Name = "Matrícula")]
    public string? Registry { get; set; }

    [Display(Name = "Data de Demissão")]
    public DateTime? ResignationDate { get; set; }

    [Display(Name = "PIS")]
    public string? PIS { get; set; }

    [Display(Name = "Cargo")]
    public EPost Post { get; set; }

    [Display(Name = "Salário")]
    public Decimal? Salary { get; set; }
}


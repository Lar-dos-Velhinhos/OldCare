namespace OldCare.Web.Models;

[Table("Comorbidity")]
public class Comorbidity : Entity
{
    [Display(Name = "Residente")]
    public Guid ResidentId { get; set; }

    public virtual Resident? Resident { get; set; }

    [Display(Name = "Descrição")]
    public string Description { get; set; }

    [Display(Name = "Data de Término")]
    public DateTime? EndDate { get; set; } = null;

    [Display(Name = "Observação")]
    public string? Note { get; set; }

    [Display(Name = "Restrição")]
    public string? Restriction { get; set; }

    [Display(Name = "Data de Início")]
    public DateTime StartDate { get; set; } = DateTime.Now;
}
namespace OldCare.Web.Models;


[Table("Occurrence")]
public class Occurrence : Entity
{
    [Display(Name = "Residente")]
    public Guid ResidentId { get; set; }

    public virtual Resident? Resident { get; set; }

    [Display(Name = "Descrição")]
    public string? Description { get; set; }

    [Display(Name = "Data da Ocorrência")]
    public DateTime OccurrenceDate { get; set; }

    [Display(Name = "Tipo")]
    public EOccurrenceType OccurrenceType { get; set; }
}
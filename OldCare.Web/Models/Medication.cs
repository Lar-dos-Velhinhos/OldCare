namespace OldCare.Web.Models;

[Table("Medication")]
public class Medication : Entity
{
    [Display(Name = "Profissinal de Saúde")]
    public Guid EmploeeId { get; set; }

    public virtual Emploee? Emploee { get; set; }

    [Display(Name = "Item da Prescrição")]
    public Guid PrescriptionItemId { get; set; }

    public virtual PrescriptionItem? PrescriptionItem { get; set; }

    [Display(Name = "Data da Medicação")]
    public DateTime? MedicationDate { get; set; }

    [Display(Name = "Observação")]
    public string? Note { get; set; }
}
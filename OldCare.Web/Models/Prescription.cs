namespace OldCare.Web.Models;

[Table("Prescription")]
public class Prescription : Entity
{
    [Display(Name ="Residente")]
    public Guid ResidentId { get; set; }

    public virtual Resident? Resident { get; set; }

    [Display(Name = "Autor da Prescrição")]
    public string  Author { get; set; }

    [Display(Name = "Encerrada?")]
    public bool IsCompleted { get; set; }

    [Display(Name = "Data da Prescrição")]
    public DateTime PrescriptionDate { get; set; }
}
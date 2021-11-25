namespace OldCare.Web.Models;

[Table("PrescriptionItem")]
public class PrescriptionItem : Entity
{
    [Display(Name ="Prescrição")]
    public Guid PrescriptionId { get; set; }

    public virtual Prescription? Prescription { get; set; }

    [Display(Name = "Produto")]
    public Guid ProductId { get; set; }

    public Product? Product { get; set; }

    [Display(Name ="Via de Administração")]
    public EAdministrationVia AdministrationVia { get; set; }

    [Display(Name = "Quantidade")]
    public double Amount { get; set; }

    [Display(Name = "Frequência")]
    public int Frequency { get; set; }

    [Display(Name = "Intervalo")]
    public EInterval Interval { get; set; }

    [Display(Name = "Encerrado?")]
    public bool IsCompleted { get; set; }

    [Display(Name = "Observação")]
    public string? Note { get; set; }

    [Display(Name ="Apresentação")]
    public string? Presentation { get; set; }
}
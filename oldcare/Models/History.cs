namespace OldCare.Web.Models;

[Table("History")]
public class History : Entity
{
    [Display(Name = "Descrição")]
    public string Description { get; set; }

    [Display(Name = "Tipo")]
    public EHistoryType HistoryType { get; set; }

    [Display(Name = "Categoria")]
    public ECategoria Categoria { get; set; }
}
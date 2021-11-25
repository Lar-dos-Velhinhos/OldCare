namespace OldCare.Web.Models;

[Table("FinancialRecord")]
public class FinancialRecord : Entity
{
    [Display(Name ="Cliente")]
    public Guid ClientId { get; set; }

    public virtual Client? Client { get; set; }

    [Display(Name = "Histórico")]
    public Guid HistoryId { get; set; }

    public virtual History? History { get; set; }

    [Display(Name = "Data do Lançamento")]
    public DateTime AccountingEntryDate { get; set; }

    [Display(Name = "Tipo Documento")]
    public string Document { get; set; }

    [Display(Name = "Número do Documento")]
    public string DocumentNumber { get; set; }

    [Display(Name = "Valor em R$")]
    public decimal MonetaryValue { get; set; }

    [Display(Name = "Observação")]
    public string Note { get; set; }
}


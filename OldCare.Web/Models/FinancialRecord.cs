namespace OldCare.Web.Models;

public class FinancialRecord : Entity
{
    public Guid ClientId { get; set; }
    public virtual Client? Person { get; set; }
    public Guid HistoryId { get; set; }
    public virtual History? Bedroom { get; set; }
    public DateTime AccountingEntryDate { get; set; }
    public string Document { get; set; }
    public string DocumentNumber { get; set; }
    public decimal MonetaryValue { get; set; }
    public string Note { get; set; }
}


namespace OldCare.Web.Models;

public class History : Entity
{
    public string  Descriction { get; set; }
    public bool HistoryType { get; set; }

    public ECategoria Categoria { get; set; }
}


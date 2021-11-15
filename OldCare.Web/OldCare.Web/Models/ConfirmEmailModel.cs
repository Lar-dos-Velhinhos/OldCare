namespace OldCare.Web.Models;

public class ConfirmEmailModel
{
    [TempData]
    public string StatusMessage { get; set; }
}

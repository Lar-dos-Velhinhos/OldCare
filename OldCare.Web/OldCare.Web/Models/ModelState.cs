namespace OldCare.Web.Models;

public abstract class ModelState
{
    [TempData]
    public string? StatusMessage { get; set; }
}

namespace OldCare.Web.Models;

public class ConfirmEmailChangeModel : ModelState
{
    public string? UserId { get; set; }
    public string? Email { get; set; }
    public string? Code { get; set; }
}

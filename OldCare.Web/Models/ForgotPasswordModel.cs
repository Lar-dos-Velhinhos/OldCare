namespace OldCare.Web.Models;

public class ForgotPasswordModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
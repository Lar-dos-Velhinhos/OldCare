namespace OldCare.Web.Models;

public class EmailModel : ModelState
{
    public string Email { get; set; }
    public bool IsEmailConfirmed { get; set; }
    [Required]
    [EmailAddress]
    [Display(Name = "Novo e-mail")]
    public string NewEmail { get; set; }
}
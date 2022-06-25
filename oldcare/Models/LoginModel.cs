namespace OldCare.Web.Models;

public class LoginModel
{
    public string ReturnUrl { get; set; }

    [TempData]
    public string ErrorMessage { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Manter conectado?")]
    public bool RememberMe { get; set; }
}
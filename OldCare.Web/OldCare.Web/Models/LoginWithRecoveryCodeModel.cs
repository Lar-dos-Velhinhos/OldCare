namespace OldCare.Web.Models;

public class LoginWithRecoveryCodeModel
{
    public string ReturnUrl { get; set; }

    [BindProperty]
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Código de recuperação")]
    public string RecoveryCode { get; set; }
}

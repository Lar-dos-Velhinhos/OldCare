namespace OldCare.Web.Models
{
    public class LoginWith2faModel
    {
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }

        [Required]
        // TODO: Translate this message to pt-br.
        [StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Código de autenticação")]
        public string TwoFactorCode { get; set; }

        [Display(Name = "Lembrar deste dispositivo.")]
        public bool RememberMachine { get; set; }
    }
}

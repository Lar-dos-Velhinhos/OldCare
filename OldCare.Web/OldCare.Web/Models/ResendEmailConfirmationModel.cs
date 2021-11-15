namespace OldCare.Web.Models
{
    public class ResendEmailConfirmationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

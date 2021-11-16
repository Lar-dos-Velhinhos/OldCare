namespace OldCare.Web.Models
{
    public class AccountManagerIndexModel : ModelState
    {
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
    }
}

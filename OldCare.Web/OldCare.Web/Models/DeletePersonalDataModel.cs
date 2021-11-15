namespace OldCare.Web.Models;

public class DeletePersonalDataModel
{
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RequirePassword { get; set; }

}
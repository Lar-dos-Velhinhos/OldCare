namespace OldCare.Web.Models;

[Table("Responsible")]
public class Responsible : Entity
{
    
    public virtual Person? Person { get; set; }
    
    public virtual Resident? Resident { get; set; }

    [Display(Name = "Data Final")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Encaminhou?")]
    public bool Forwarder { get; set; }

    [Display(Name = "Parentesco")]
    public EKinship Kinship { get; set; }

    [Display(Name = "Principal?")]
    public bool Primary { get; set; }

    [Display(Name = "Data de Início")]
    public DateTime StartDate { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

[Table("ResidentResponsible")]
public class ResidentResponsible : Entity
{
    public Resident Resident { get; set; }
    public Responsible Responsible { get; set; }
    public bool Forwarder { get; set; }
    public DateOnly EndDate { get; set; }
    public bool Primary { get; set; }
    public DateOnly StartDate { get; set; }
}


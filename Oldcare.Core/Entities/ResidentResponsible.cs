using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Entities;

[Table("ResidentResponsible")]
public class ResidentResponsible : Entity
{
    public Resident Resident { get; set; } = null!;
    public Responsible Responsible { get; set; } = null!;
    public bool Forwarder { get; set; }
    public DateTime EndDate { get; set; }
    public bool Primary { get; set; }
    public DateTime StartDate { get; set; }
}


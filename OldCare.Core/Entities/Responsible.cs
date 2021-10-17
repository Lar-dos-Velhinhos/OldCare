using OldCare.Core.Enums;

namespace OldCare.Core.Entities;

public class Responsible : Entity
{
    // Dependences
    public Person Person { get; set; }
    
    public EKinship Kinship { get; set; }
    public long PhoneNumber { get; set; }
}


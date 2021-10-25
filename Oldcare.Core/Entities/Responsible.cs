namespace Oldcare.Core.Entities;

public class Responsible : Entity
{
    public Person Person { get; set; }

    public EKinship Kinship { get; set; }
    public long PhoneNumber { get; set; }
}


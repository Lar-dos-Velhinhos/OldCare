using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.Enums;

namespace OldCare.Contexts.AccountContext.Entities;

public class Responsible : Entity
{
    public Person Person { get; set; }

    public EKinship Kinship { get; set; }
    public long PhoneNumber { get; set; }
}


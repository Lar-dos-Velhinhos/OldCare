using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Contexts.AccountContext.Entities;

public class Bedroom : Entity
{
    public int Capacity { get; set; }
    public bool Gender { get; set; }
    public int Number { get; set; }
}


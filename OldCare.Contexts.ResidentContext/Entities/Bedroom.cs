using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Contexts.ResidentContext.Entities;

public class Bedroom : Entity
{
    public int Capacity { get; set; }
    public bool Gender { get; set; }
    public int Number { get; set; }
    public List<Resident>? Residents { get; set; }
}


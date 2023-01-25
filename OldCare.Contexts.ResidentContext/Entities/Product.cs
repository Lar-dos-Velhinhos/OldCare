using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Contexts.ResidentContext.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public string UnitOfMeasurement { get; set; }
}


using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.AccountContext.Entities;

public class Role : Entity
{
    protected Role()
    {
        Tracker = new Tracker("Criação da role.");
    }

    public string Name { get; } = string.Empty;

    public static implicit operator string(Role role) => role.Name;

    public override string ToString() => Name;
}
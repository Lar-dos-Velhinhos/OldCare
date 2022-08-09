using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.AccountContext.Entities;

public class BlackList : Entity
{
    protected BlackList()
    {
    }

    public BlackList(string email)
    {
        Email = email;
        Tracker = new();
    }

    public Email Email { get; } = null!;
    public Tracker Tracker { get; } = null!;
}
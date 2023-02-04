using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.AccountContext.Entities;

public class BlackList : Entity
{
    protected BlackList()
    {
        Tracker = new Tracker("Criação do registro.");
    }

    public BlackList(string email)
    {
        Email = email;
        Tracker = new();
    }

    public Email Email { get; } = null!;
}
using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.AccountContext.Entities;

public class UserRole : Entity
{
    protected UserRole()
    {
        Tracker = new Tracker("Criação do relacionamento.");
    }

    public Role Role { get; } = null!;
    public Guid RoleId { get; } = Guid.Empty;
    public User User { get; } = null!;
    public Guid UserId { get; } = Guid.Empty;
    public DateTime? StartDate { get; } = null;
    public DateTime? EndDate { get; } = null;
    public bool IsActive => StartDate > DateTime.UtcNow && EndDate <= DateTime.UtcNow;
}
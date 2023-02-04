using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.SharedContext.Entities;

public abstract class Entity
{
    #region Public Properties

    public Guid Id { get; } = Guid.NewGuid();
    public Tracker Tracker { get; set; } = new Tracker("Criação da entidade.");

    #endregion
}
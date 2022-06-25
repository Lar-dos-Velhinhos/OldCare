namespace OldCare.Contexts.SharedContext.ValueObjects;

public class Tracker : ValueObject
{
    #region Constructors

    public Tracker(string notes = "")
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Notes = notes;
    }

    #endregion

    #region Properties

    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }
    public string Notes { get; private set; }

    #endregion

    #region Methods

    public void Update(string notes = "")
    {
        UpdatedAt = DateTime.UtcNow;
        Notes = notes;
    }

    #endregion

    #region Overloads

    public static implicit operator string(Tracker tracker) =>
        $"Última atualização em {tracker.UpdatedAt:dd/MM/yyyy HH:mm:ss}";

    public override string ToString() => $"Última atualização em {UpdatedAt:dd/MM/yyyy HH:mm:ss}";

    #endregion
}
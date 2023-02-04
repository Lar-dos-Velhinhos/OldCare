using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.Enums;

namespace OldCare.Contexts.ResidentContext.Entities;

public class Occurrence : Entity
{
    #region Public Constructors

    public Occurrence()
    {
        Tracker = new("Criação da ocorrência.");
    }

    #endregion
    
    #region Public Properties

    public string Description { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
    public DateTime OccurrenceDate { get; set; } = DateTime.UtcNow;
    public EOccurrenceType OccurrenceType { get; set; } = EOccurrenceType.General;
    public Resident Resident { get; set; } = null!;

    #endregion

    #region Overloads

    public static implicit operator String(Occurrence occurrence)
        => occurrence.Description;

    #endregion
}


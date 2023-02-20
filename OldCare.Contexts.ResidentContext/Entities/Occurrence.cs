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

    public Occurrence(string description,
        bool isDeleted,
        DateTime occurrenceDate,
        EOccurrenceType occurrenceType,
        Resident resident)
    {
        Description = description;  
        IsDeleted = isDeleted;
        OccurrenceDate = occurrenceDate;
        OccurrenceType = occurrenceType;
        Resident = resident;
    }

    #endregion
    
    #region Public Properties

    public string Description { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
    public DateTime OccurrenceDate { get; set; } = DateTime.UtcNow;
    public EOccurrenceType OccurrenceType { get; set; } = EOccurrenceType.General;
    public Resident Resident { get; set; } = null!;

    #endregion

    #region Public Methods

    public void ChangeOccurrence(string description,
        bool isDeleted, DateTime occurrenceDate,
        EOccurrenceType occurrenceType)
    {
        Description = description;
        IsDeleted = isDeleted;
        OccurrenceDate = occurrenceDate;
        OccurrenceType = occurrenceType;
    }
    #endregion

    #region Overloads

    public static implicit operator String(Occurrence occurrence)
        => occurrence.Description;

    #endregion
}


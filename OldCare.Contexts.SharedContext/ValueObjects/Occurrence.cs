using OldCare.Contexts.SharedContext.Enums;

namespace OldCare.Contexts.SharedContext.ValueObjects;

public class Occurrence : ValueObject
{
    public string Description { get; set; }
    public DateTime OccurrenceDate { get; set; }
    public EOccurrenceType OccurrenceType { get; set; }
}


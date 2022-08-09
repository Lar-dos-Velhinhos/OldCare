namespace OldCare.Contexts.SharedContext.ValueObjects;

public class Utm : ValueObject
{
    public Utm(
        string? source = null,
        string? campaign = null,
        string? content = null,
        string? medium = null)
    {
        Source = source;
        Campaign = campaign;
        Content = content;
        Medium = medium;
    }

    public string? Source { get; }
    public string? Campaign { get; } 
    public string? Content { get; }

    public string? Medium { get; }
}
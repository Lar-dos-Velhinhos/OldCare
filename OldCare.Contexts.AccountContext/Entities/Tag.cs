using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.AccountContext.Entities;

public class Tag : Entity
{
    protected Tag()
    {
    }

    public Tag(string slug, string title, string description, bool isPublic = false)
    {
        Slug = slug;
        Title = title;
        Description = description;
        Tracker = new Tracker();
        IsPublic = isPublic;
    }

    public string Slug { get; private set; } = string.Empty;
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Tracker Tracker { get; private set; } = new();
    public bool IsPublic { get; private set; } = false;
    public IReadOnlyCollection<Student>? Students { get; private set; } = null;
}
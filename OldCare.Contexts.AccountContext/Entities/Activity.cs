using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Contexts.AccountContext.Entities;

public class Activity : Entity
{
    protected Activity()
    {
    }

    public Activity(string title, string? description = null)
    {
        Title = title;
        Description = description;
        Date = DateTime.UtcNow;
    }

    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; } = string.Empty;
    public DateTime Date { get; private set; } = DateTime.UtcNow;
}
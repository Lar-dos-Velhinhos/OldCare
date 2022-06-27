using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.AccountContext.UseCases.Details.Models;

public class DetailsModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Document>? Documents { get; set; } = new();
    public DateTime? Birthdate { get; set; }
    public string? Phone { get; set; } = string.Empty;
    public string? Title { get; set; } = string.Empty;
    public string? Bio { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
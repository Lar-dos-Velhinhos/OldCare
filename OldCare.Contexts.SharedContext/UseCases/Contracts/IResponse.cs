using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.SharedContext.UseCases.Contracts;

public interface IResponse
{
    public IReadOnlyCollection<Error>? Errors { get; }
    public int StatusCode { get; }
    public bool IsSuccess { get; }
}
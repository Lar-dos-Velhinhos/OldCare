namespace OldCare.Contexts.SharedContext.ValueObjects;

public record Error
{
    #region Constructors

    public Error(string value, string key = "")
    {
        Key = string.IsNullOrEmpty(key)
            ? Guid.NewGuid().ToString().Replace("-", "")[..8]
            : key;
        Value = value;
    }

    #endregion

    #region Properties

    public string Key { get; } = string.Empty;
    public string Value { get; } = string.Empty;

    #endregion
}
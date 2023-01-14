namespace OldCare.Contexts.SharedContext.Enums;

/// <summary>
/// Determinate log type and target (local, environment or production)
/// </summary>
public enum ELogType
{
    LocalException = 0,
    LocalApplicationEvent = 1,
    LocalUserActivity = 2
}
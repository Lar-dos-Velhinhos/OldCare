namespace OldCare.Contexts.SharedContext.Enums;

/// <summary>
/// Determinate log type and target (local, environment or production)
/// </summary>
public enum ELogType
{
    ApplicationEvent = 0,
    Error = 1,
    UserActivity = 2,
    Warning = 3
}
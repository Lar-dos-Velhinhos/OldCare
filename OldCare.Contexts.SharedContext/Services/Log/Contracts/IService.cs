namespace OldCare.Contexts.SharedContext.Services.Log.Contracts;

public interface IService
{
    // TODO: Verificar a razão do arquivo não subir
    Task LogAsync(string message, string key = "", string data = "");
    Task LogWarningAsync(string message);
    Task LogErrorAsync(string message, string key = "");
    Task LogErrorAsync(Exception ex, string key = "", string data = "");

    Task AppendMessageAsync(string message);
    Task AppendWarningMessageAsync(string message);
    Task AppendErrorMessageAsync(string message);
    Task LogBatchAsync(string message);
}
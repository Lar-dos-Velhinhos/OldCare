using OldCare.Contexts.SharedContext.Enums;
using RestSharp;

namespace OldCare.Contexts.SharedContext.Services.Log.Contracts;

public interface IService
{
    /// <summary>
    /// Configure log request to send
    /// </summary>
    /// <param name="logType">Log type to send</param>
    /// <param name="message">Log message to send</param>
    /// <param name="key">Log key to identify handler message</param>
    /// <param name="data">Log data to return</param>
    /// <returns></returns>
    Task LogAsync(ELogType logType, string message, string key = "", string data = "");
    Task LogWarningAsync(string message);
    Task AppendMessageAsync(string message);
    Task AppendWarningMessageAsync(string message);
    Task AppendErrorMessageAsync(string message);
    Task LogBatchAsync(string message);

    /// <summary>
    /// Send log asynchronous
    /// </summary>
    /// <param name="logType">Log type to send</param>
    /// <param name="request">Log request to send</param>
    /// <returns></returns>
    Task SendAsync(ELogType logType, RestRequest request);
}
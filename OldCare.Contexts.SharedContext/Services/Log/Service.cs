using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.Services.Log.Contracts;
using RestSharp;

namespace OldCare.Contexts.SharedContext.Services.Log;

public class Service : IService
{
    public async Task LogAsync(
        ELogType logType,
        string message)
    {
        var body = new
        {
            username = "OldCare",
            avatar_url = "",
            content = $"{message}"
        };

        var request = new RestRequest().AddJsonBody(body);
        await SendAsync(logType, request);
    }

    public async Task LogAsync(
        ELogType logType,
        string message,
        string key,
        string data)
    {
        if (string.IsNullOrEmpty(key))
            key = "Não Associado";
        
        if (!string.IsNullOrEmpty(data))
            data = $"\n\n**Detalhes**\n{data}";
        
        var body = new
        {
            username = "OldCare",
            avatar_url = "",
            content = $"**[{key}]** {message};{data}"
        };

        var request = new RestRequest().AddJsonBody(body);
        await SendAsync(logType, request);
    }

    public async Task LogWarningAsync(string message) => await Task.Delay(1);

    public async Task AppendMessageAsync(string message) => await Task.Delay(1);

    public async Task AppendWarningMessageAsync(string message) => await Task.Delay(1);

    public async Task AppendErrorMessageAsync(string message) => await Task.Delay(1);

    public async Task LogBatchAsync(string message) => await Task.Delay(1);

    public async Task SendAsync(ELogType logType, RestRequest request)
    {
        switch (logType)
        {
            case ELogType.LocalException:
                var exceptionClient = new RestClient(Configuration.Discord.Webhooks.ExceptionsUrl);
                await exceptionClient.PostAsync(request);
                break;
        }
    }
}
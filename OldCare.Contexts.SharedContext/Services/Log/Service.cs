using OldCare.Contexts.SharedContext.Services.Log.Contracts;
using RestSharp;

namespace OldCare.Contexts.SharedContext.Services.Log;

public class Service : IService
{
    public async Task LogAsync(string message)
    {
        var body = new
        {
            username = "",
            avatar_url = "",
            content = $"{message}"
        };

        var request = new RestRequest().AddJsonBody(body);
        var client = new RestClient(Configuration.Discord.Webhooks.LogsUrl);

        await client.PostAsync(request);
    }
    
    public async Task LogAsync(
        string message,
        string key = "",
        string data = "")
    {
        var body = new
        {
            username = "",
            avatar_url = "h",
            content = $"**Código**\n{key}\n\n**Mensagem**\n{message}\n\n**Detalhes**\n{data}"
        };

        var request = new RestRequest().AddJsonBody(body);
        var client = new RestClient(Configuration.Discord.Webhooks.LogsUrl);

        await client.PostAsync(request);
    }

    public async Task LogWarningAsync(string message) => await Task.Delay(1);

    public async Task LogErrorAsync(string message, string key = "") => await LogAsync(message);

    public async Task LogErrorAsync(
        Exception ex,
        string key = "",
        string data = "") => await LogAsync("Erro na aplicação", key, ex.Message);

    public async Task AppendMessageAsync(string message) => await Task.Delay(1);

    public async Task AppendWarningMessageAsync(string message) => await Task.Delay(1);

    public async Task AppendErrorMessageAsync(string message) => await Task.Delay(1);

    public async Task LogBatchAsync(string message) => await Task.Delay(1);
}
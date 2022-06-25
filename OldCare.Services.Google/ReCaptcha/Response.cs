using System.Text.Json.Serialization;

namespace OldCare.Services.Google.ReCaptcha;

public class Response
{
    [JsonPropertyName("success")] public bool Success { get; set; }
    [JsonPropertyName("challenge_ts")] public DateTime ChallengeTs { get; set; }
    [JsonPropertyName("hostname")] public string HostName { get; set; } = string.Empty;
    [JsonPropertyName("error-codes")] public string[]? Errors { get; set; }
}
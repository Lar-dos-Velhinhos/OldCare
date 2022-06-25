using OldCare.Contexts.SharedContext.UseCases.Contracts;

namespace OldCare.Contexts.AccountContext.UseCases.Authenticate;

public class ResponseData : IResponseData
{
    public ResponseData()
    {
    }

    public ResponseData(string id, string name, string email, string[] roles)
    {
        Id = id;
        Name = name;
        Email = email;
        Roles = roles;
    }

    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string[] Roles { get; set; } = Array.Empty<string>();
}
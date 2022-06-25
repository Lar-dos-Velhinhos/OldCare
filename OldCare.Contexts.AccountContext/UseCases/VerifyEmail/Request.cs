using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OldCare.Contexts.SharedContext.Extensions;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.VerifyEmail;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    [DisplayName("E-mail")]
    [Required(ErrorMessage = "E-mail inválido")]
    [StringLength(160, MinimumLength = 5, ErrorMessage = "O E-mail deve conter entre 5 e 160 caracteres")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;

    [DisplayName("Código de verificação")]
    [Required(ErrorMessage = "Código de verificação inválido")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "O código de verificação deve conter 8 caracteres")]
    public string VerificationCode { get; set; } = string.Empty;

    public string GoogleReCaptchaResponse { get; set; } = string.Empty;

    public string? Hash { get; set; }
    public string? ReturnUrl { get; set; }

    public void LoadDataFromHash()
    {
        try
        {
            var data = Hash?.FromBase64().Split(":");
            Email = data?[0] ?? string.Empty;
            VerificationCode = data?[1] ?? string.Empty;
        }
        catch
        {
            // ignored
        }
    }
    
    public string[]? ExtractDataFromHash()
    {
        try
        {
            var data = Hash?.FromBase64().Split(":");
            return data;
        }
        catch
        {
            // ignored
            return null;
        }
    }
}
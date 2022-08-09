using System.ComponentModel.DataAnnotations;
using OldCare.Contexts.SharedContext.Extensions;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.ResetPassword;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "E-mail inválido")]
    [StringLength(160, MinimumLength = 5, ErrorMessage = "O E-mail deve conter entre 5 e 160 caracteres")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;
    
    [Display(Name = "Código de verificação")]
    [Required(ErrorMessage = "Código de verificação inválido")]
    public string? VerificationCode { get; set; } = string.Empty;
    
    [Display(Name = "Nova senha")]
    [Required(ErrorMessage = "Senha inválida")]
    [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha antiga deve conter entre 8 e 30 caracteres")]
    public string Password { get; set; } = string.Empty;
    
    [Display(Name = "Confirme sua senha")]
    [Required(ErrorMessage = "Confirmação de senha inválida")]
    [StringLength(40, MinimumLength = 8, ErrorMessage = "A senha deve conter entre 3 e 40 caracteres")]
    [Compare("Password", ErrorMessage = "As senhas digitadas não coincidem")]
    public string ConfirmPassword { get; set; } = string.Empty;
    
    public string GoogleReCaptchaResponse { get; set; } = string.Empty;
    
    public string? ReturnUrl { get; set; } = null;
    
    public void LoadDataFromVerificationCode()
    {
        try
        {
            var data = VerificationCode?.FromBase64().Split(":");
            Email = data?[1] ?? string.Empty;
        }
        catch
        {
            // ignored
        }
    }
}
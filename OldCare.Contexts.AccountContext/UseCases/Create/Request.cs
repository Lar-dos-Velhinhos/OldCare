using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.Create;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    [DisplayName("Nome")]
    [Required(ErrorMessage = "Nome inválido")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 40 caracteres")]
    public string FirstName { get; set; } = string.Empty;

    [DisplayName("Sobrenome")]
    [Required(ErrorMessage = "Sobrenome inválido")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O sobrenome deve conter entre 3 e 40 caracteres")]
    public string LastName { get; set; } = string.Empty;

    [DisplayName("E-mail")]
    [Required(ErrorMessage = "E-mail inválido")]
    [StringLength(160, MinimumLength = 5, ErrorMessage = "O E-mail deve conter entre 5 e 160 caracteres")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;
    
    [DisplayName("Senha")]
    [Required(ErrorMessage = "Senha inválida")]
    [StringLength(40, MinimumLength = 8, ErrorMessage = "A senha deve conter entre 3 e 40 caracteres")]
    public string Password { get; set; } = string.Empty;
 
    [DisplayName("Confirme sua senha")]
    [Required(ErrorMessage = "Confirmação de senha inválida")]
    [StringLength(40, MinimumLength = 8, ErrorMessage = "A senha deve conter entre 3 e 40 caracteres")]
    [Compare("Password", ErrorMessage = "As senhas digitadas não coincidem")]
    public string ConfirmPassword { get; set; } = string.Empty;

    public string GoogleReCaptchaResponse { get; set; } = string.Empty;

    public bool AcceptTerms { get; set; } = true;
    public bool SubscribeToNewsletter { get; set; } = true;
    
    public string? UtmSource { get; set; } = null;
    public string? UtmCampaign { get; set; } = null;
    public string? UtmContent { get; set; } = null;
    public string? UtmMedium { get; set; } = null;
    public string? ReturnUrl { get; set; } = null;
}
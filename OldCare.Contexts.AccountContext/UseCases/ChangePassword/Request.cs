using System.ComponentModel.DataAnnotations;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.ChangePassword;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    public string Email { get; set; } = string.Empty;
    
    [Display(Name = "Senha antiga")]
    [Required(ErrorMessage = "Senha inválida")]
    [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha antiga deve conter entre 8 e 30 caracteres")]
    public string OldPassword { get; set; } = string.Empty;
    
    [Display(Name = "Nova senha")]
    [Required(ErrorMessage = "Senha inválida")]
    [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha antiga deve conter entre 8 e 30 caracteres")]
    public string NewPassword { get; set; } = string.Empty;
    
    [Display(Name = "Confirmar nova senha")]
    [Required(ErrorMessage = "Confirmação de senha inválida")]
    [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha antiga deve conter entre 8 e 30 caracteres")]
    public string NewPasswordConfirmation { get; set; } = string.Empty;
}
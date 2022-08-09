using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.ChangeEmail;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    public string OldEmail { get; set; } = string.Empty;
    
    [Display(Name = "Novo E-mail")]
    [Required(ErrorMessage = "E-mail inválido")]
    [StringLength(160, MinimumLength = 5, ErrorMessage = "O E-mail deve conter entre 5 e 160 caracteres")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string NewEmail { get; set; } = string.Empty;
    
    [DisplayName("Senha")]
    [Required(ErrorMessage = "Senha inválida")]
    [StringLength(40, MinimumLength = 8, ErrorMessage = "A senha deve conter entre 3 e 40 caracteres")]
    public string Password { get; set; } = string.Empty;
}
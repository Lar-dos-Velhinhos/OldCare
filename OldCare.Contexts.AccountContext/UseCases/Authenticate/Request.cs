using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.Authenticate;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    [DisplayName("E-mail")]
    [Required(ErrorMessage = "E-mail inválido")]
    [StringLength(160, MinimumLength = 5, ErrorMessage = "O E-mail deve conter entre 5 e 160 caracteres")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;

    [DisplayName("Senha")]
    [Required(ErrorMessage = "Senha inválida")]
    public string Password { get; set; } = string.Empty;

    public string? ReturnUrl { get; set; }
}
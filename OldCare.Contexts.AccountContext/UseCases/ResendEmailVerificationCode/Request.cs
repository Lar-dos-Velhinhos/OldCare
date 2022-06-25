using System.ComponentModel.DataAnnotations;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.ResendEmailVerificationCode;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "E-mail inválido")]
    [StringLength(160, MinimumLength = 5, ErrorMessage = "O E-mail deve conter entre 5 e 160 caracteres")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;

    public string GoogleReCaptchaResponse { get; set; } = string.Empty;
}
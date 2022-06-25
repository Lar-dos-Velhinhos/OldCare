using System.ComponentModel.DataAnnotations;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.VerifyPhone;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    public string Email { get; set; } = string.Empty;
    
    [Display(Name = "Telefone")]
    [Required(ErrorMessage = "Telefone inválido")]
    [StringLength(20, MinimumLength = 11, ErrorMessage = "O telefone deve conter entre 11 e 20 caracteres")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Display(Name = "Código de verificação")]
    [Required(ErrorMessage = "Código de verificação inválido")]
    [StringLength(6, MinimumLength = 6, ErrorMessage = "O código de verificação deve conter 6 caracteres")]
    public string VerificationCode { get; set; } = string.Empty;
}
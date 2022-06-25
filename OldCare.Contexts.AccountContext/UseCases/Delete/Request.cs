using System.ComponentModel.DataAnnotations;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;

namespace OldCare.Contexts.AccountContext.UseCases.Delete;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "É necessário confirmar que você leu e concorda com o aviso")]
    public bool ConfirmDelete { get; set; }

    [Required(ErrorMessage = "Selecione uma opção")]
    public EEvasionReason FeedbackOption { get; set; }

    [MaxLength(255, ErrorMessage = "A mensagem deve conter um tamanho máximo de 255 caracteres")]
    public string? FeedbackMessage { get; set; }
    
    [Display(Name = "Confirme sua senha")]
    [Required(ErrorMessage = "Senha inválida")]
    [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha antiga deve conter entre 8 e 30 caracteres")]
    public string Password { get; set; } = string.Empty;

    public string? ReturnUrl { get; set; }
}
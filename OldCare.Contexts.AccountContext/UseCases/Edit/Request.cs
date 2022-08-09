using System.ComponentModel.DataAnnotations;
using OldCare.Contexts.SharedContext.UseCases;
using MediatR;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.AccountContext.UseCases.Edit;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "E-mail inválido")]
    [StringLength(160, MinimumLength = 5, ErrorMessage = "O E-mail deve conter entre 5 e 160 caracteres")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "Nome inválido")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 40 caracteres")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Sobrenome")]
    [Required(ErrorMessage = "Sobrenome inválido")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O sobrenome deve conter entre 3 e 40 caracteres")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "CPF")]
    [Required(ErrorMessage = "CPF é necessário para continuar")]
    public List<Document>? Documents { get; set; }

    [Display(Name = "Telefone")]
    [Required(ErrorMessage = "Número de telefone inválido")]
    [StringLength(20, MinimumLength = 11, ErrorMessage = "O número do telefone deve conter entre 11 e 20 caracteres")]
    public string? Phone { get; set; }

    [Display(Name = "Data de nascimento")]
    [Required(ErrorMessage = "A data de nascimento é necessária para continuar")]
    public DateTime? BirthDate { get; set; } = DateTime.UtcNow;
}
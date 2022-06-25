using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OldCare.Contexts.AccountContext.UseCases.Details.Models;
using OldCare.Contexts.SharedContext.UseCases.Contracts;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.AccountContext.UseCases.Details;

public class ResponseData : IResponseData
{
    public ResponseData(DetailsModel detailsModel)
    {
        StudentId = detailsModel.Id.ToString();
        FirstName = detailsModel.FirstName;
        LastName = detailsModel.LastName;
        Email = detailsModel.Email;
        Document = detailsModel.Document;
        BirthDate = detailsModel.Birthdate;
        Phone = detailsModel.Phone;
        Title = detailsModel.Title;
        Bio = detailsModel.Bio;
        CreatedAt = detailsModel.CreatedAt;
    }

    public string StudentId { get; }
    
    [DisplayName("Nome")]
    [Required(ErrorMessage = "Nome inválido")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 40 caracteres")]
    public string FirstName { get; }
    
    [DisplayName("Sobrenome")]
    [Required(ErrorMessage = "Sobrenome inválido")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O sobrenome deve conter entre 3 e 40 caracteres")]
    public string LastName { get; set; }
    
    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "E-mail inválido")]
    [StringLength(160, MinimumLength = 5, ErrorMessage = "O E-mail deve conter entre 5 e 160 caracteres")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; }

    [Display(Name = "CPF")]
    [Required(ErrorMessage = "CPF é necessário para continuar")]
    public string Document { get; set; }
    
    [Display(Name = "Data de nascimento")]
    [Required(ErrorMessage = "A data de nascimento é necessária para continuar")]
    public DateTime? BirthDate { get; set; }
    
    // [Display(Name = "Celular")]
    // [Required(ErrorMessage = "Número de telefone inválido")]
    // [StringLength(20, MinimumLength = 11, ErrorMessage = "O número do telefone deve conter entre 11 e 20 caracteres")]
    public string? Phone { get; }
    
    [Display(Name = "Título")]
    [MaxLength(80, ErrorMessage = "O título deve conter um máximo de 160 caracteres")]
    public string? Title { get; }
    
    [Display(Name = "Biografia")]
    [MaxLength(1024, ErrorMessage = "A biografia deve conter um máximo de 160 caracteres")]
    public string? Bio { get; }
    public DateTime CreatedAt { get; }
}
using System.ComponentModel.DataAnnotations;

namespace OldCare.Core.ViewModels.Person;

public class CreatePersonViewModel
{
    public Guid Id { get; set; }
    
    [MaxLength(255, ErrorMessage = "O tamanho máximo de 255 caracteres foi atingido")]
    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public string Address { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    [MaxLength(180, ErrorMessage = "O tamanho máximo de 180 caracteres foi atingido")]
    public string Citizenship { get; set; }
    
    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public int CEP { get; set; }
    
    [MaxLength(180, ErrorMessage = "O tamanho máximo de 180 caracteres foi atingido.")]
    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public string City { get; set; }
    
    public int CPF { get; set; }
    
    [MaxLength(180, ErrorMessage = "O tamanho máximo de 180 caracteres foi atingido")]
    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public string District { get; set; }
    
    public bool Gender { get; set; }
    
    [MaxLength(255, ErrorMessage = "O tamanho máximo de 255 caracteres foi atingido")]
    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public string Name { get; set; }
    
    [MaxLength(255, ErrorMessage = "O tamanho máximo de 255 caracteres foi atingido")]
    public string Note { get; set; }
    
    public long RG { get; set; }
    
    [StringLength(2, ErrorMessage = "O tamanho necessário é de 2 caracteres.")]
    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public string UF { get; set; }
}
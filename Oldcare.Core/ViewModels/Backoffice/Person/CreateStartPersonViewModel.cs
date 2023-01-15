using System.ComponentModel.DataAnnotations;

namespace Oldcare.Core.ViewModels.Backoffice.Person;

public class CreateStartPersonViewModel
{
    public Guid Id { get; set; }
    
    [Display(Name = "Nome")]
    [MaxLength(255, ErrorMessage = "O campo \'nome\' da pessoa precisa conter um máximo de 255 caracteres.")]
    [MinLength(2, ErrorMessage = "O campo \'nome\' da pessoa precisa conter ao menos 2 letras.")]
    [Required(ErrorMessage = "O campo \'nome\' não pode estar vazio.")]
    public string Name { get; set; }
    
    [Display(Name = "Data de nascimento")]
    public DateTime? BirthDate { get; set; }
    
    [Display(Name = "Naturalidade")]
    public string? Citizenship { get; set; }
    
    [Display(Name = "Gênero")]
    [Required(ErrorMessage = "Uma opção válida de \'gênero\' deve ser selecionada.")]
    public bool Gender { get; set; }
    
    [Display(Name = "RG")]
    public long? RG { get; set; }
    
    [Display(Name = "CPF")]
    public long? CPF { get; set; }
}
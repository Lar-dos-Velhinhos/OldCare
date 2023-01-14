using System.ComponentModel.DataAnnotations;

namespace OldCare.Core.ViewModels.Backoffice.Person;

public class CreateEndPersonViewModel : CreateStartPersonViewModel
{
    [Display(Name = "Endereço")]
    [MaxLength(255, ErrorMessage = "O campo \'endereço\' precisa ter um tamanho máximode 255 caracteres.")]
    [MinLength(4, ErrorMessage = "O campo \'endereço\' precisa ter um tamanho mínimo de 4 caracteres.")]
    [Required(ErrorMessage = "O campo \'endereço\' não pode estar vazio.")]
    public string Address { get; set; }

    [Display(Name = "Número")]
    public string AddressNumber { get; set; } = "N/A";
    
    [Display(Name = "Bairro")]
    [MaxLength(180, ErrorMessage = "O campo \'bairro\' precisa ter um tamanho máximo de 180 caracteres.")]
    [MinLength(4, ErrorMessage = "O campo \'bairro\' precisa ter um tamanho mínimo de 4 caracteres.")]
    [Required(ErrorMessage = "O campo \'bairro\' não pode estar vazio.")]
    public string District { get; set; }
    
    [Display(Name = "Cidade")]
    [MaxLength(180, ErrorMessage = "O campo \'cidade\' precisa ter um tamanho máximo de 180 caracteres.")]
    [MinLength(4, ErrorMessage = "O campo \'cidade\' precisa ter um tamanho mínimo de 4 caracteres.")]
    [Required(ErrorMessage = "O campo \'cidade\' não pode estar vazio.")]
    public string City { get; set; }
    
    [Display(Name = "Estado")]
    [Required(ErrorMessage = "Uma opção válida de \'estado\' deve ser selecionada.")]
    public string UF { get; set; }
    
    [Display(Name = "CEP")]
    public int? CEP { get; set; }
    
    [Display(Name = "Observação")]
    public string Note { get; set; }
}
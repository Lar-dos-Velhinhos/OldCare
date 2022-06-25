using System.ComponentModel.DataAnnotations;

namespace OldCare.Contexts.SharedContext.Enums;

public enum EEvasionReason
{
    [Display(Name = "Outros")]
    Others = 0,
    
    [Display(Name = "A didática não me cativou")]
    UnattractiveDidactics = 1,
    
    [Display(Name = "O conteúdo não era o que eu esperava")]
    DisappointingContent = 2,
    
    [Display(Name = "Apenas desejo excluir minhas informações")]
    JustDeleteInformation = 3
}
using System.ComponentModel.DataAnnotations;

namespace OldCare.Contexts.SharedContext.Enums;

public enum EDocumentType
{
    [Display(Name = "CNH")]
    CNH = 1,
    [Display(Name = "CPF")]
    Cpf = 2,
    [Display(Name = "RG")]
    RG = 3,
    [Display(Name = "Passaporte")]
    Passport = 4,
    [Display(Name = "PIS/NIT")]
    PISNIT = 5,
}
using System.ComponentModel.DataAnnotations;

namespace OldCare.Contexts.SharedContext.Enums;

public enum EDocumentType
{
    [Display(Name = "CNH")]
    CNH = 1,
    [Display(Name = "CPF")]
    Cpf = 2,
    [Display(Name = "RG")]
    RG = 2,
    [Display(Name = "Passaporte")]
    Passport = 1,
    [Display(Name = "PIS/NIT")]
    PISNIT = 1,
}
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.Extensions;

namespace OldCare.Contexts.SharedContext.ValueObjects;

public class Document : ValueObject
{
    #region Ctors

    protected Document()
    {
    }
    
    public Document(
        string? number,
        EDocumentType type = EDocumentType.Cpf)
    {
        Number = number.ToNumbersOnly();
        Type = type;
    }

    #endregion

    #region Properties
    
    public string Number { get; private set; } = string.Empty;
    public EDocumentType Type { get; }
    
    #endregion

    #region Methods

    public bool IsCpf()
    {
        int[] multiplierA = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplierB = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        Number = Number.Trim();
        Number = Number.Replace(".", "").Replace("-", "");
        if (Number.Length != 11)
            return false;
        var tempCpf = Number.Substring(0, 9);
        var soma = 0;

        for(int i=0; i<9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplierA[i];
        
        var resto = soma % 11;
        
        if ( resto < 2 )
            resto = 0;
        else
            resto = 11 - resto;
        
        var digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        
        for(int i=0; i<10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplierB[i];
        
        resto = soma % 11;
        
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        
        digito = digito + resto.ToString();
        return Number.EndsWith(digito);
    }

    #endregion

    #region Overloads

    public static implicit operator string(Document document) => document?.Number ?? string.Empty;

    public static implicit operator Document(string? number) => new(number);

    #endregion
}
namespace OldCare.Web.Models;

public class Client : Entity
{
    [Display(Name ="CPF/CNPJ")]
    public long CPFCNPJ { get; set; }
    [Display(Name ="Nome ou Razão Social")]
    public string Name { get; set; }

}


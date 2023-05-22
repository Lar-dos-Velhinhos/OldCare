using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.Enums;

namespace OldCare.Contexts.SharedContext.Entities;

public class Document : Entity
{
    #region Public Constructors

    public Document() { } 

    public Document(string documentNumber, EDocumentType documentType, bool isDeleted, Person person)
    {
        DocumentNumber = documentNumber;
        DocumentType = documentType;
        IsDeleted= isDeleted;
        Person = person;
    }

    #endregion

    #region Public Properties

    public string DocumentNumber { get; set; } = string.Empty;
    public EDocumentType DocumentType { get; set; } = EDocumentType.RG;
    public bool IsDeleted { get; set; }
    public Person Person { get; set; } = null!;

    #endregion

    #region Public Methods

    public void ChangeDocument(string documentNumber,
        EDocumentType documentType, bool isDeleted,
        Person person)
    {
        DocumentNumber = documentNumber;
        DocumentType = documentType;
        IsDeleted = isDeleted;
        Person = person;
    }
    #endregion
}

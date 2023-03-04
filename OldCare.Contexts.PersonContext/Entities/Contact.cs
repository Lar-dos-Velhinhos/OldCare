using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.Enums;

namespace OldCare.Contexts.AccountContext.Entities;

public class Contact : Entity
{
    #region Public Constructors

    public Contact()
    {
    }

    public Contact(EContactType contactType,
        string description, bool isDeleted, string? note)
    {
        ContactType = contactType;
        Description = description;
        IsDeleted = isDeleted;
        Note = note;
    }

    #endregion

    #region Public Properties

    public EContactType ContactType { get; set; } = EContactType.CelPhone;
    public string Description { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public string? Note { get; set; } = null;

    #endregion

    #region Public Methods

    public void ChangeContact(EContactType contactType,
        string description, bool isDeleted, string? note)
    {
        ContactType = contactType;
        Description = description;
        IsDeleted = isDeleted;
        Note = note;
    }

    #endregion
}

using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.Extensions;
using OldCare.Contexts.SharedContext.UseCases.Contracts;
using OldCare.Contexts.SharedContext.ValueObjects;
using OldCare.Contexts.SharedContext.ValueObjects.Exceptions;
using SecureIdentity.Password;

namespace OldCare.Contexts.AccountContext.Entities;

public class User : Entity, IAggregateRoot
{
    #region Constructors

    protected User()
    {
    }

    public User(string email, string password = "", bool forceChangePassword = true)
    {
        Username = email;
        Password = new Password(password, forceChangePassword);
        Active = true;
        Tracker = new Tracker("Criação do usuário");
    }

    #endregion

    #region Properties

    public Email Username { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
    public Tracker Tracker { get; } = null!;
    public Person Person { get; private set; }
    public bool Active { get; private set; }

    #endregion

    #region Computed Properties

    public bool CanLogIn =>
        Active &&
        Username.Verification.IsVerified &&
        !Password.Expired;

    #endregion

    #region Methods
    
    public void Authenticate(string password)
    {
        var ss = PasswordHasher.Hash(password);
        var result = PasswordHasher.Verify(
            Password.Hash,
            password,
            privateKey: SharedContext.Configuration.Secrets.PrivateKey);

        if (!result)
            throw new Exception("Usuário ou senha inválidos");

        if (!CanLogIn)
            throw new Exception("Conta com acesso bloqueado");

        if (!Username.Verification.IsVerified)
            throw new Exception("Conta não verificada");

        Tracker.Update("Realizou login");
    }

    public bool ChallengePassword(string password)
        => Password.Challenge(password);

    public void VerifyEmail(string verificationCode, string notes = "E-mail verificado")
    {
        Username.Verification.Verify(verificationCode);
        Tracker.Update(notes);
    }

    public void Activate(string notes = "Conta ativada")
    {
        if (Username.Verification.IsVerified == false)
            throw new UnverifiedEmailException();

        Active = true;
        Tracker.Update(notes);
    }

    public void EraseData()
    {
        var id = Guid.NewGuid().ToString()[..8];
        Username = $"{id}@mail.com";
        Password = new Password();
        Tracker.Update("Dados exluídos");
    }

    public void Inactivate(bool expireEmail = false, string notes = "Conta inativada")
    {
        Active = false;

        if (expireEmail)
            Username.Expire();

        Tracker.Update(notes);
    }

    public void ChangeUsername(Email email, string notes = "E-mail alterado")
    {
        Username = email;
        Tracker.Update(notes);
    }

    public void ChangePassword(string password, bool expireEmail = false, string notes = "Senha alterada")
    {
        Password = new Password(password);

        if (expireEmail)
            Username.Expire();

        Tracker.Update(notes);
    }
    
    public void GenerateEmailVerificationCode()
    {
        Username.GenerateVerificationCode();
        Tracker.Update("Código de verificação recriado");
    }

    private void ResetPassword(string newPassword, bool expireEmail = false, string notes = "Senha restaurada")
    {
        Password = new Password(newPassword);

        if (expireEmail)
            Username.Expire();

        Tracker.Update(notes);
    }
    
    public void ResetPassword(string password, string base64Code)
    {
        try
        {
            var data = base64Code.FromBase64().Split(":");
            var email = data[1];
            var id = data[0];

            if (email.ToLower() != Username || Id.ToString().ToLower() != id.ToLower())
                throw new Exception("Código de ativação inválido!");
        }
        catch
        {
            throw new Exception("Código de ativação inválido!");
        }

        ResetPassword(password, true, "Senha alterada.");
    }

    #endregion

    #region Overloads

    public static implicit operator string(User user) => user.Username;
    public override string ToString() => Username;

    #endregion
}
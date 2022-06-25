using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.Extensions;
using OldCare.Contexts.SharedContext.UseCases.Contracts;
using OldCare.Contexts.SharedContext.ValueObjects;
using SecureIdentity.Password;

namespace OldCare.Contexts.AccountContext.Entities;

public class Student : Entity, IAggregateRoot
{
    #region Constructors

    protected Student()
    {
    }

    public Student(
        string firstName,
        string lastName,
        string email,
        string? title = null,
        string? bio = null,
        Utm? utm = null)
    {
        Name = new Name(firstName, lastName);
        Email = new Email(email);
        User = new User(email);
        Title = title;
        Bio = bio;
        Tracker = new Tracker("Criação da conta");
        Utm = utm;
    }

    public Student(
        string firstName,
        string lastName,
        string email,
        string password,
        string? title = null,
        string? bio = null,
        Utm? utm = null)
    {
        Name = new Name(firstName, lastName);
        Email = new Email(email);
        User = new User(email, password, false);
        Title = title;
        Bio = bio;
        Tracker = new Tracker("Criação da conta");
        Utm = utm;
    }

    public Student(
        Name name,
        Email email,
        User user,
        string? title = null,
        string? bio = null,
        Utm? utm = null)
    {
        Name = name;
        Email = email;
        User = user;
        Title = title;
        Bio = bio;
        Tracker = new Tracker("Criação da conta");
        Utm = utm;
    }

    public Student(
        Name name,
        Email email,
        string? title = null,
        string? bio = null,
        Utm? utm = null)
    {
        Name = name;
        Email = email;
        User = new User(email, forceChangePassword: true);
        Title = title;
        Bio = bio;
        Tracker = new Tracker("Criação da conta");
        Utm = utm;
    }

    #endregion

    #region Properties

    public Name Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Phone? Phone { get; private set; }
    public Document? Document { get; private set; } = string.Empty;
    public DateTime? BirthDate { get; private set; }
    public User User { get; } = null!;
    public string? Title { get; private set; }
    public string? Bio { get; private set; }
    public Tracker Tracker { get; } = null!;
    public Utm? Utm { get; }

    public List<Tag>? Tags { get; private set; } = null;
    public List<Activity> Activities { get; private set; } = new();

    #endregion

    #region Methods

    public void ChangeEmail(string address)
    {
        if (User is null)
            throw new NullReferenceException("Usuário não encontrado");

        Tracker.Update($"E-mail alterado de {Email} para {address}");
        Email.Update(address);
        User.ChangeUsername(address);
    }

    public void ChangePassword(string password)
    {
        if (User is null)
            throw new NullReferenceException("Usuário não encontrado");

        User.ChangePassword(password);
        Tracker.Update("Senha alterada.");
    }

    public void ChangePhone(Phone phone)
    {
        Phone = phone;
        Tracker.Update("Número de telefone modificado.");
    }

    public void ChangeInformation(
        string firstName,
        string lastName,
        string document,
        DateTime? birthDate,
        string? title = null,
        string? bio = null)
    {
        Name = new Name(firstName, lastName);
        Title = title;
        Bio = bio;
        Document = document;
        BirthDate = birthDate;

        Tracker.Update();
    }

    public void EraseData(EEvasionReason evasionReason, string? feedbackMessage)
    {
        Name = new("erased", "data");
        Email = new($"{Id}@mail.com");
        Phone = new(00, 00, "00000000");
        Title = "erased data";
        Bio = "erased data";
        User.EraseData();

        if (!string.IsNullOrEmpty(feedbackMessage))
            Tracker.Update($"{evasionReason} | {feedbackMessage}");
        else
            Tracker.Update($"{evasionReason} | Dados exluídos");
    }

    public void GenerateEmailVerificationCode()
    {
        Email.GenerateVerificationCode();
        Tracker.Update("Código de verificação recriado");
    }

    public void GeneratePhoneVerificationCode()
    {
        Phone?.GenerateVerificationCode();
        Tracker.Update("Código de verificação de telefone recriado");
    }

    public bool IsActive()
        => User.Active;

    public void ResetPassword(string password, string base64Code)
    {
        try
        {
            var data = base64Code.FromBase64().Split(":");
            var email = data[1];
            var id = data[0];

            if (email.ToLower() != Email || Id.ToString().ToLower() != id.ToLower())
                throw new Exception("Código de ativação inválido!");
        }
        catch
        {
            throw new Exception("Código de ativação inválido!");
        }

        User.ResetPassword(password, true, "Senha alterada.");
    }

    public void VerifyEmail(string code)
    {
        Email.Verification.Verify(code);
        Tracker.Update("Email verificado");
    }

    public void VerifyPhone(string code)
    {
        Phone?.Verification.Verify(code);
        Tracker.Update("Telefone verificado");
    }

    public void Authenticate(string password)
    {
        var result = PasswordHasher.Verify(
            User.Password.Hash,
            password,
            privateKey: SharedContext.Configuration.Secrets.PrivateKey);

        if (!result)
            throw new Exception("Usuário ou senha inválidos");

        if (!IsActive())
            throw new Exception("Usuário ou senha inválidos");

        if (!Email.Verification.IsVerified)
            throw new Exception("Conta não verificada");

        Tracker.Update("Realizou login");
    }

    public void AddDefaultTags(List<Tag> tags, bool includePromos = true)
    {
        var promoTag = tags.FirstOrDefault(x => x.Slug == "promos");
        if (promoTag != null && !includePromos)
            tags.Remove(promoTag);

        Tags = new List<Tag>();
        foreach (var tag in tags)
            Tags.Add(tag);
    }

    public void AddTag(Tag tag)
    {
        Tags ??= new List<Tag>();
        Tags.Add(tag);
    }

    public void AddActivity(string title, string? description = null)
        => Activities.Add(new Activity(title, description));

    #endregion

    #region Overloads

    public override string ToString() => Name;

    #endregion
}
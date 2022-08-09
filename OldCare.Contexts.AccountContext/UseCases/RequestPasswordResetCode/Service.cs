using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.RequestPasswordResetCode.Contracts;
using OldCare.Contexts.SharedContext.Extensions;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OldCare.Contexts.AccountContext.UseCases.RequestPasswordResetCode;

public class Service : IService
{
    public async Task SendPasswordVerificationCodeAsync(User user, string? returnUrl = null)
    {
        const string subject = "Recuperação de senha";
        
        var apiKey = SharedContext.Configuration.SendGrid.ApiKey;
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("hello@lardosvelhinhosgta@gmail.com", "OldCare");
        var to = new EmailAddress(user.Username, user.Person.Name);
        var base64Code = $"{user.Id}:{user.Username}".ToBase64();
        var url = returnUrl is null
            ? $"{SharedContext.Configuration.Host}/minha-conta/senha/restaurar/{base64Code}"
            : $"{SharedContext.Configuration.Host}/minha-conta/senha/restaurar/{base64Code}?returnUrl={returnUrl}";
        var body =
            $"<link rel='preconnect' href='https://fonts.googleapis.com'><link rel='preconnect' href='https://fonts.gstatic.com' crossorigin><link href='https://fonts.googleapis.com/css2?family=Heebo:wght@300&display=swap' rel='stylesheet'><div style='font-family: Heebo; width: 600px; margin: auto;'> <img src='https://domain.blob.core.windows.net/public/site/assets/images/email/activate_account_header.jpg'/><br><br>Olá, <strong>{user.Username}</strong>, como estão as coisas por aí?<br><br>Recebemos uma solicitação de recuperação de senha para esta conta e estamos verificando se foi você quem a fez. Clique no botão abaixo para criar uma nova senha.<br><br><br><a style='background: #3D3445; border-radius: 4px; color: #fff; padding: 20px; text-decoration: none; width: 265px;font-weight: 600;font-size: 15px;line-height: 100%;' href='{url}'>Criar uma nova senha 👉</a> <br><br><br>Caso não tenha solicitado a recuperação da sua senha, por favor, desconsidere este e-mail. <hr> <br><small><strong>Precisa de ajuda?</strong><br>Sempre que precisar de qualquer auxílio acesse nossa <strong><a href='https://OldCare/ajuda'>Central de Ajuda e Suporte</a></strong></small>.<br><br><br></div>";
        var message = MailHelper.CreateSingleEmail(from, to, subject, body, body);
        await client.SendEmailAsync(message);
    }
}
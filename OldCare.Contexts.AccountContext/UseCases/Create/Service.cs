using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.Create.Contracts;
using OldCare.Contexts.SharedContext.Extensions;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OldCare.Contexts.AccountContext.UseCases.Create;

public class Service : IService
{
    public async Task SendEmailVerificationCodeAsync(Student student, string? returnUrl)
    {
        const string subject = "Confirme sua conta e comece a estudar";

        var apiKey = SharedContext.Configuration.SendGrid.ApiKey;
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("hello@balta.io", "balta.io");
        var base64Code = $"{student.Email}:{student.Email.Verification.Code}".ToBase64();
        var url = returnUrl is null
            ? $"{SharedContext.Configuration.Host}/minha-conta/email/verificar/{base64Code}"
            : $"{SharedContext.Configuration.Host}/minha-conta/email/verificar/{base64Code}?returnUrl={returnUrl}";
        var to = new EmailAddress(student.Email, student.Name);
        var body =
            $"<link rel='preconnect' href='https://fonts.googleapis.com'><link rel='preconnect' href='https://fonts.gstatic.com' crossorigin><link href='https://fonts.googleapis.com/css2?family=Heebo:wght@300&display=swap' rel='stylesheet'><div style='font-family: Heebo; width: 600px; margin: auto;'><img src='https://baltastorage.blob.core.windows.net/public/site/assets/images/email/activate_account_header.jpg'/><br><br>Olá, <strong>{student.Name}</strong>, seja bem-vindo(a) ao <strong>balta.io</strong>.<br><br>Está quase tudo pronto para você começar seus estudos, basta clicar no botão abaixo para verificar seu E-mail e ativar sua conta na plataforma.<br><br><br><a style='background: #3D3445; border-radius: 4px; color: #fff; padding: 20px; text-decoration: none; width: 265px;font-weight: 600;font-size: 15px;line-height: 100%;' href='{url}'>Começar meus estudos 👉</a> <br><br><br><hr><br><small><strong>Precisa de ajuda?</strong><br>Sempre que precisar de qualquer auxílio acesse nossa <strong><a href='https://balta.io/ajuda'>Central de Ajuda e Suporte</a></strong></small>.<br><br><br></div>";
        var message = MailHelper.CreateSingleEmail(from, to, subject, body, body);
        await client.SendEmailAsync(message);
    }
}
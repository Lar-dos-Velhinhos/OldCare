using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.VerifyEmail.Contracts;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OldCare.Contexts.AccountContext.UseCases.VerifyEmail;

public class Service : IService
{
    public async Task SendAccountVerifiedEmailAsync(Student student)
    {
        var apiKey = SharedContext.Configuration.SendGrid.ApiKey;

        const string subject = "Próximos passos...";
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("hello@balta.io", "balta.io");
        var to = new EmailAddress(student.Email, student.Name);
        var body =
            $"<link rel='preconnect' href='https://fonts.googleapis.com'><link rel='preconnect' href='https://fonts.gstatic.com' crossorigin><link href='https://fonts.googleapis.com/css2?family=Heebo:wght@300&display=swap' rel='stylesheet'><div style='font-family: Heebo; width: 600px; margin: auto;'><img src='https://baltastorage.blob.core.windows.net/public/site/assets/images/email/student_guide_header.jpg'/><br><br>Olá, <strong>{student.Name}</strong>, sua jornada no <strong>balta.io</strong> começa agora!<br><br>Para aproveitar melhor todos os benefícios da nossa plataforma, preparamos este guia para orientar seus estudos conosco.<br><h2>Por onde devo começar?</h2>Esta é uma ótima pergunta, e não se preocupe pois já deixamos tudo pronto para você.<br><br>Todo nosso conteúdo é segmentado em <strong>carreiras</strong> e nós recomendamos que comece pelo <strong>Backend</strong> com <strong>.NET</strong>. <br><br>Esta carreira vai te dar toda base necessária para fazer qualquer curso do balta.io, todos os fundamentos serão passados aqui.<br><br><br><a style='background: #3D3445; border-radius: 4px; color: #fff; padding: 20px; text-decoration: none; width: 265px;font-weight: 600;font-size: 15px;line-height: 100%;' href='https://dotnet.balta.io'>Começar meus estudos 🚀</a><br><br><br><hr><h2>Quero algo diferente...</h2>Embora a carreira .NET seja a mais <strong>recomendada</strong>, sinta-se livre para ver qual conteúdo se adequa melhor a sua situação atual.<br><br><br><a style='border: 2px solid #3D3445; border-radius: 4px; color: #3D3445; padding: 15px; text-decoration: none; width: 265px;font-weight: 600;font-size: 15px;line-height: 100%;' href='https://carreiras.balta.io'>Quero conhecer as carreiras 😍</a><br><br><br><hr><h2>Aprenda algo novo todos os dias...</h2>Cadastre-se para receber nossa <strong>newsletter</strong> e receba uma notificação sempre que publicarmos algum conteúdo novo.<br><br><br><a style='border: 2px solid #3D3445; border-radius: 4px; color: #3D3445; padding: 15px; text-decoration: none; width: 265px;font-weight: 600;font-size: 15px;line-height: 100%;' href='https://news.balta.io/'>Quero receber as novidades 📰</a><br><br><br><hr><br><strong>Precisa de ajuda?</strong><br>Sempre que precisar de qualquer auxílio acesse nossa <strong><a href='https://balta.io/ajuda'>Central de Ajuda e Suporte</a></strong>.<br><br><br></div>";
        var message = MailHelper.CreateSingleEmail(from, to, subject, body, body);
        await client.SendEmailAsync(message);
    }
}
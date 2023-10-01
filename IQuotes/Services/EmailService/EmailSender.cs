using IQuotes.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace IQuotes.Services.EmailService;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;
    
    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Task SendEmail(ViewEmail viewEmail)
    {
        var emailHost=_configuration.GetSection("EmailHost").Value;
        var emailPassword = _configuration.GetSection("EmailPassword").Value;
        var emailUsername = _configuration.GetSection("EmailUsername").Value;

        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(emailUsername));
        email.To.Add(MailboxAddress.Parse(viewEmail.To));
        email.Subject = viewEmail.Subject;
        email.Body = new TextPart(TextFormat.Html){ Text=viewEmail.Body};

        //create new smtp client,connect, authenticate and send message
        var smtp = new SmtpClient();
        smtp.Connect(emailHost, 587, SecureSocketOptions.StartTls);
        smtp.Authenticate(emailUsername,emailPassword);
        smtp.Send(email);
        smtp.Disconnect(true);
        return Task.CompletedTask;
    }
}
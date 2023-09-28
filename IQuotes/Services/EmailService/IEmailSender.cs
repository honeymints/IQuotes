using IQuotes.Models;

namespace IQuotes.Services.EmailService;

public interface IEmailSender
{
    public Task SendEmail(ViewEmail viewEmail);

}
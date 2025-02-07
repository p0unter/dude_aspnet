namespace _5_entity.Models;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}
namespace LMSService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string subject, string body, string templateName);
    }
}

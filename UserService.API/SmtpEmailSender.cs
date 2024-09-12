using Microsoft.Extensions.Options;

using System.Net.Mail;


namespace LMSService
{
    public class SmtpEmailSender(ILogger<SmtpEmailSender> logger,
                       IOptions<MailserverConfiguration> mailserverOptions) : IEmailSender
    {
        private readonly ILogger<SmtpEmailSender> _logger = logger;
        private readonly MailserverConfiguration _mailserverConfiguration = mailserverOptions.Value!;

        public async Task SendEmailAsync(string to, string subject, string body, string templateName)
        {
            var emailClient = new SmtpClient(_mailserverConfiguration.Hostname, _mailserverConfiguration.Port);
            emailClient.Credentials = new System.Net.NetworkCredential(_mailserverConfiguration.SMTPUserId, _mailserverConfiguration.SMTPUserPassword);
            emailClient.EnableSsl = true;
            //emailClient.UseDefaultCredentials = false;
            // emailClient.DeliveryMethod=SmtpDeliveryMethod.Network;
            // emailClient.TargetName = "STARTTLS/smtp.office365.com";
            var bodypart = File.ReadAllText($"{_mailserverConfiguration.TemplateFolderPath}{templateName}.html")
                                             .Replace("[Manager]", "Gowri")
                                             .Replace("[RESOURCENAME]", "Mohammed Majeed")
                                             .Replace("[DisassociateLink]", "http://your-disassociation-link.com");
            try
            {
                var message = new MailMessage
            {
                From = new MailAddress(_mailserverConfiguration.FromEmail),
                Subject = subject,
                    Body= bodypart
    ,
                IsBodyHtml = true
            };

                //Body = File.ReadAllText($"{_mailserverConfiguration.TemplateFolderPath}{templateName}.html")
                //                            .Replace("[UserName]", "majeed")
                //                            .Replace("[DisassociateLink]", "http://your-disassociation-link.com")
            message.To.Add(new MailAddress(to));
            message.To.Add(new MailAddress("gowrishankar.bura@qentelli.com"));
            /*message.To.Add(new MailAddress("mohd.majeed@qentelli.com"))*/;
            
            await emailClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Sending email to {to}  with subject {subject} using {type}.", to, subject, ex.Message.ToString());
            }
        }
    }
}

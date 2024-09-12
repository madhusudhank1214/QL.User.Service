namespace LMSService
{
    public class MailserverConfiguration()
    {
        public string Hostname { get; set; } = "localhost";
        public int Port { get; set; } = 25;

        public string FromEmail { get; set; } = string.Empty;
        public string SMTPUserId { get; set; } = string.Empty;
        public string SMTPUserPassword { get; set; } = string.Empty;

        public string TemplateFolderPath { get; set; } = string.Empty;


    }
}

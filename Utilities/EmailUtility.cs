using System.Net.Mail;
using System.Net;

namespace BioKudi.Utilities
{
    public class EmailUtility
    {
        private SmtpClient client;
        private MailMessage email;
        private string Host = "smtp.gmail.com";
        private int Port = 587;
        // Change the values to Google passkey for the email account
        private string User = "openlibrarynotify@gmail.com"; 
        private string Password = "ciaxznzmzyiulxgt";
        private bool EnabledSSL = true;

        public EmailUtility()
        {
            client = new SmtpClient(Host, Port)
            {
                EnableSsl = EnabledSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(User, Password)
            };
        }

        public void SendEmail(string destiny, string affair, string message, bool isHtml)
        {
            try
            {
                email = new MailMessage(User, destiny, affair, message);
                email.IsBodyHtml = isHtml;
                client.Send(email);
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }

        }
    }
}
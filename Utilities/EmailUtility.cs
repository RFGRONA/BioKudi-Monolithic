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

        public string templateEmail(string name)
        {
            string email = "<!DOCTYPE html><html lang='en' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:v='urn:schemas-microsoft-com:vml'><head><title></title><meta content='text/html; charset=utf-8' http-equiv='Content-Type'/><meta content='width=device-width, initial-scale=1.0' name='viewport'/><style>body {margin: 0;padding: 0;background-color: #ffffff;-webkit-text-size-adjust: none;text-size-adjust: none;text-align: center;color: #000000;font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif;}a[x-apple-data-detectors] {color: inherit !important;text-decoration: inherit !important;}p {line-height: 1.6;color: #203558;}.button_block {text-align: center;}.alignment {display: inline-block;}.button_block a {margin-top: 10px;text-decoration: none;display: inline-block;color: #ffffff;background-color: #002027;border-radius: 15px;padding: 8px 20px;font-size: 16px;text-align: center;}h1 {color: #002027;margin-bottom: 20px;text-align: center;}.footer {color: #F67924;font-size: 14px;line-height: 1.6;text-align: center;padding: 10px;}.image-container {text-align: center;padding: 1em;background: #D8EECE;}.image-container img {display: inline-block;max-width: 100%;height: auto;}</style></head><body><table border='0' cellpadding='0' cellspacing='0' role='presentation' width='100%'><tr><td><table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' width='100%'><tr><td><table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' width='680'><tr><td><div class='image-container'><img align='center' alt='company Logo' class='icon' height='auto' src='https://i.imgur.com/UOCk6pM.png' style='display: block; height: auto; margin: 0 auto; border: 0; min-width: 20em;' width='117'/></div><h1>Bienvenido "+ name +"</h1><p>Te has registrado satisfactoriamente. </p><p>Esperamos puedas disfrutar de la página y de todo lo que tenemos para ofrecerte. </p><div></div><div class='footer'><em><strong>Este correo se genera automáticamente, por favor no lo responda.</strong></em><em><br>Si necesitas contactarnos puedes hacerlo por medio de un ticket.</em></div></td></tr></table></td></tr></table></td></tr></table></body></html>";
            return email;
        }
    }
}
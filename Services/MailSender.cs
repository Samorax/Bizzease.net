using Microsoft.Extensions.OptionsModel;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SendGrid;

namespace WebApplication_Webease_.Services
{

    public class MailSender:IMailSender
    {
        private IOptions<WebMail> _webmailsettings;

        public string Message { get; set; }

        public MailSender(IOptions<WebMail> webmailsettings)
        {
            _webmailsettings = webmailsettings;
        }

        public async Task SendMessage(string To, string Subject, string Message)
        {
            var message = new SendGridMessage();
            message.AddTo(To);
            message.Subject = Subject;
            message.Text = Message;
            message.From = new MailAddress(_webmailsettings.Value.Email);

            var credentials = new NetworkCredential(_webmailsettings.Value.SendGridUsername, _webmailsettings.Value.SendGridPassword);
            var transportWeb = new Web(credentials);

            await transportWeb.DeliverAsync(message);
           
        }

        
    }
}
using System.Threading.Tasks;

namespace WebApplication_Webease_.Services
{
    public interface IMailSender
    {
        Task SendMessage(string To, string Subject, string Message);
    }
}

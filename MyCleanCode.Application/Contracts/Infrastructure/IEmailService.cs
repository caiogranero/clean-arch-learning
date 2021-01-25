using System.Threading.Tasks;

namespace MyCleanCode.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task SendEmail();
    }

    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
    
}
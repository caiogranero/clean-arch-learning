using System.Threading.Tasks;
using MyCleanCode.Application.Contracts.Infrastructure;

namespace MyCleanCode.Infrastructure
{
    public class EmailService : IEmailService
    {
        public Task SendEmail()
        {
            return Task.CompletedTask;
        }
    }
}
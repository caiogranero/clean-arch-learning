using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCleanCode.Application.Contracts.Infrastructure;
using MyCleanCode.Persistence;

namespace MyCleanCode.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
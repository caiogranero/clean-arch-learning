using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// using MyCleanCode.Application.Contracts.Persistence;
// using MyCleanCode.Persistence.Repositories;

namespace MyCleanCode.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceSerices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CleanCodeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
            
            // services.AddScoped<ICategoryRepository, CategoryRepository>();
            // services.AddScoped<IOrderRepository, OrderRepository>();
            // services.AddScoped<IEventRepository, EventRepository>();

            return services;
        }
    }
}
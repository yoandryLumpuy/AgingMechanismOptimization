using Core;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSqlServerContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PhoenixContext>(dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

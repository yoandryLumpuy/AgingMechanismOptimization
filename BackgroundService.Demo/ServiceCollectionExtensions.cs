using BackgroundService.Demo.Configurations;
using BackgroundService.Demo.HostedServices;
using Microsoft.Extensions.Options;

namespace BackgroundService.Demo
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBackgroundServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<BackgroundServicesOptions>(configuration.GetSection(nameof(BackgroundServicesOptions)));

            services.AddSingleton<CronExpressions>(serviceProvider =>
            {
                var backgroundServicesOptions = serviceProvider.GetRequiredService<IOptions<BackgroundServicesOptions>>().Value;
                return new CronExpressions(backgroundServicesOptions);
            });

            services.AddHostedService<AgedTransactionsProcessingBackgroundService>();

            return services;
        }
    }
}

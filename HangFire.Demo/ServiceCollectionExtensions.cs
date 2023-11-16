using Hangfire;
using Hangfire.Common;
using HangFire.Demo.Configurations;
using HangFire.Demo.Jobs;
using Microsoft.Extensions.Options;

namespace HangFire.Demo
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHangFireServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<HangFireJobsOptions>(configuration.GetSection(nameof(HangFireJobsOptions)));

            services.AddHangfire(config => config.UseSqlServerStorage(configuration.GetConnectionString("HangFireConnection")));
            services.AddHangfireServer();

            return services;
        }


        public static IApplicationBuilder UseHangFireServices(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();

             var recurringJobManager = app.ApplicationServices.GetRequiredService<IRecurringJobManager>();

             var hangFireJobsOptions = app.ApplicationServices.GetRequiredService<IOptions<HangFireJobsOptions>>().Value;

             recurringJobManager.AddOrUpdate(nameof(MyJob), 
                 new Job(typeof(MyJob).GetMethod(nameof(IJob.ExecuteAsync))), hangFireJobsOptions.CronExpression);

            return app;
        }
    }
}

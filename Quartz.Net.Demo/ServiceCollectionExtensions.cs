using Quartz.Net.Demo.Job;
using System.Configuration;
using Quartz.Net.Demo.Exceptions;

namespace Quartz.Net.Demo
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQuartzServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddQuartz(q =>
            {
                q.AddJobAndTrigger<MyJob>(configuration);
            });
            
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            return services;
        }


        private static void AddJobAndTrigger<T>(this IServiceCollectionQuartzConfigurator quartz, IConfiguration config) where T : IJob
        {
            var jobName = typeof(T).Name;

            var configKey = $"Quartz:{jobName}";
            var cronSchedule = config[configKey];

            if (string.IsNullOrEmpty(cronSchedule))
            {
                throw new AddJobAndTriggerException($"No Quartz.NET Cron schedule found for job in configuration at {configKey}");
            }

            var jobKey = new JobKey(jobName);
            quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

            quartz.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity(jobName + "-trigger")
                .WithCronSchedule(cronSchedule)); // use the schedule from configuration
        }
    }
}

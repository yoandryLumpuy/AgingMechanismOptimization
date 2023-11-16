using BackgroundService.Demo.Configurations;
using Domain.Services.Commands;
using MediatR;

namespace BackgroundService.Demo.HostedServices
{
    public class AgedTransactionsProcessingBackgroundService: Microsoft.Extensions.Hosting.BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AgedTransactionsProcessingBackgroundService> _logger;

        public AgedTransactionsProcessingBackgroundService(IServiceProvider serviceProvider, ILogger<AgedTransactionsProcessingBackgroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Checking aged transactions for changing status properly.");

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                try
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

                    await mediator.Send(new AgingTransactionCommand(), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, $"An Error occurred while trying to check drones' battery level");
                }

                var cronExpressions = scope.ServiceProvider.GetRequiredService<CronExpressions>();

                var now = DateTime.UtcNow;
                var next = cronExpressions[nameof(AgedTransactionsProcessingBackgroundService)].GetNextOccurrence(now);

                await Task.Delay(next.Value - now, stoppingToken).ConfigureAwait(false);
            }
        }
    }
}

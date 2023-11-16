using Domain.Services.Commands;
using MediatR;

namespace HangFire.Demo.Jobs
{
    public class MyJob: IJob
    {
        private readonly ISender _mediator;
        private readonly ILogger<MyJob> _logger;

        public MyJob(ISender mediator, ILogger<MyJob> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task ExecuteAsync()
        {
            try
            {
                await _mediator.Send(new AgingTransactionCommand());
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}

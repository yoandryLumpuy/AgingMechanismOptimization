using Domain.Services.Commands;
using MediatR;

namespace Quartz.Net.Demo.Job
{
    public class MyJob: IJob
    {
        private readonly ISender _mediator;

        public MyJob(ISender mediator)
        {
            _mediator = mediator;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _mediator.Send(new AgingTransactionCommand());
        }
    }
}

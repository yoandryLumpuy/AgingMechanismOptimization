using Core;
using Core.Domain;
using Domain.Services.Queries;
using MediatR;

namespace Domain.Services.Commands
{
    public class AgingTransactionCommand: IRequest
    { }


    public class AgingTransactionCommandHandler : IRequestHandler<AgingTransactionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISender _sender;

        public AgingTransactionCommandHandler(IUnitOfWork unitOfWork, ISender sender)
        {
            _unitOfWork = unitOfWork;
            _sender = sender;
        }

        public async Task Handle(AgingTransactionCommand request, CancellationToken cancellationToken)
        {
            var settings = await _sender.Send(new AgedTransactionSettingsQuery(), cancellationToken);

            if (settings?.Any() != true) return;

            var undisbursedTransactions = _unitOfWork.Transactions.Find(p => p.TransferStatusId == TransferStatusValues.Undisbursed).ToList();

            foreach (var item in undisbursedTransactions)
            {
                var days = (DateTime.UtcNow - item.Created).Days;
                var range = settings.FirstOrDefault(s => s.LowRange <= days && (s.HighRange == null || s.HighRange >= days));

                if (range == null) continue;
                
                await _sender.Send(
                    new TransactionStatusChangeCommand(item.Id, item.TransferStatusId, range.TransferStatusId), cancellationToken);
            }
        }
    }
}

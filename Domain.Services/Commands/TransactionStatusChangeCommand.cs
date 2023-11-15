using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;
using MediatR;

namespace Domain.Services.Commands
{
    public class TransactionStatusChangeCommand: IRequest<long>
    {
        public TransactionStatusChangeCommand(long transactionId, string statusBeforeId, string statusAfterId)
        {
            TransactionId = transactionId;
            StatusBeforeId = statusBeforeId;
            StatusAfterId = statusAfterId;
        }

        public long TransactionId { get; }

        public string StatusBeforeId { get; }

        public string StatusAfterId { get; }
    }

    public class TransactionStatusChangeCommandHandler : IRequestHandler<TransactionStatusChangeCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionStatusChangeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(TransactionStatusChangeCommand request, CancellationToken cancellationToken)
        {
            var item = new TransactionStatusChange()
            {
                ChangeDate = DateTime.UtcNow,
                StatusAfterId = request.StatusAfterId,
                StatusBeforeId = request.StatusBeforeId,
                TransactionId = request.TransactionId
            };

            _unitOfWork.TransactionStatusChanges.Add(item);

            _unitOfWork.Complete();

            return item.Id;
        }
    }
}

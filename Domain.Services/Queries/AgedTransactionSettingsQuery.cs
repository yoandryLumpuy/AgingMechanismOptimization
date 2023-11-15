using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;
using MediatR;

namespace Domain.Services.Queries
{
    public class AgedTransactionSettingsQuery: IRequest<IEnumerable<AgedTransactionSettings>>
    { }

    public class AgedTransactionSettingsQueryHandler : IRequestHandler<AgedTransactionSettingsQuery, IEnumerable<AgedTransactionSettings>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AgedTransactionSettingsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AgedTransactionSettings>> Handle(AgedTransactionSettingsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.AgedTransactionSettings.GetAll();
        }
    }
}

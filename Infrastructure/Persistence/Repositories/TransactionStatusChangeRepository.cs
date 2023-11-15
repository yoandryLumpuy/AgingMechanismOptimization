using Core.Domain;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class TransactionStatusChangeRepository: Repository<TransactionStatusChange>, ITransactionStatusChangeRepository
    {
        public TransactionStatusChangeRepository(DbContext context) : base(context)
        { }

        public PhoenixContext PhoenixDbContext => DbContextAs<PhoenixContext>()!;
    }
}

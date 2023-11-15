using Core.Domain;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class TransactionsRepository: Repository<Transaction>, ITransactionRepository
    {
        public TransactionsRepository(DbContext context) : base(context)
        { }

        public PhoenixContext PhoenixDbContext => DbContextAs<PhoenixContext>()!;
    }
}

using Core;
using Core.Repositories;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhoenixContext _context;

        public ITransactionRepository Transactions { get; }

        public IAgedTransactionSettingsRepository AgedTransactionSettings { get; }

        public ITransactionStatusChangeRepository TransactionStatusChanges { get; }

        public UnitOfWork(PhoenixContext context)
        {
            _context = context;

            AgedTransactionSettings = new AgedTransactionSettingsRepository(context);
            Transactions = new TransactionsRepository(context);
            TransactionStatusChanges = new TransactionStatusChangeRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
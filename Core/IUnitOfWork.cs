using Core.Repositories;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        ITransactionRepository Transactions { get; }

        IAgedTransactionSettingsRepository AgedTransactionSettings { get; }

        ITransactionStatusChangeRepository TransactionStatusChanges { get; }

        int Complete();
    }
}
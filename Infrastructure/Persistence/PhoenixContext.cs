using Core.Domain;
using Infrastructure.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class PhoenixContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<TransactionStatusChange> TransactionStatusChanges { get; set; }

        public DbSet<AgedTransactionSettings> AgedTransactionSettings { get; set; }

        public PhoenixContext(DbContextOptions<PhoenixContext> options): base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgedTransactionSettingsConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionStatusChangeConfiguration());
        }
    }
}

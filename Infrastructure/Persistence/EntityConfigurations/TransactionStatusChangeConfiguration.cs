using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class TransactionStatusChangeConfiguration: IEntityTypeConfiguration<TransactionStatusChange>
    {
        public void Configure(EntityTypeBuilder<TransactionStatusChange> builder)
        {
            builder.ToTable(nameof(TransactionStatusChange))
                .HasComment("Stores Transaction Status Changes History.");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasComment("History entry identifier.");
            builder.Property(p => p.StatusBeforeId).HasMaxLength(1).HasComment("Transfer status before the change.");
            builder.Property(p => p.StatusAfterId).HasComment("Current transfer status.");
            builder.Property(p => p.ChangeDate).HasComment("Date of the change.");
            builder.Property(p => p.TransactionId).HasComment("Transaction the history entry belongs to.");
        }
    }
}

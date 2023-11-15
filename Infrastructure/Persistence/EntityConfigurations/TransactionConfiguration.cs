using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class TransactionConfiguration: IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable(nameof(Transaction)).HasComment("Stores Information related with Transactions.");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasComment("The transaction's identifier.");
            builder.Property(p => p.TransactionNumber).IsRequired().HasMaxLength(128).HasComment("Unique transaction number created by the system.");
            builder.Property(p => p.Amount).HasColumnType("decimal(19,4)").HasComment("The Transaction's amount.");
            builder.Property(p => p.Created).HasComment("The UTC Date the transaction was created at.");
            builder.Property(p => p.TransferStatusId).HasComment("Status of the transaction.");
            builder.HasIndex(p => p.TransactionNumber).IsUnique();
        }
    }
}

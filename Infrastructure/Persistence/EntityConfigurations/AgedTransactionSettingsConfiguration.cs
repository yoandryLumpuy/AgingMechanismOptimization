using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class AgedTransactionSettingsConfiguration: IEntityTypeConfiguration<AgedTransactionSettings>
    {
        public void Configure(EntityTypeBuilder<AgedTransactionSettings> builder)
        {
            builder.ToTable(nameof(AgedTransactionSettings))
                .HasComment("Stores the rules to grow old the transactions automatically");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                .HasComment("Rule identifier.");

            builder.Property(p => p.LowRange)
                .HasComment("The min value of days to apply the rule.");

            builder.Property(p => p.HighRange)
                .HasComment("The max value of days to apply the rule.");

            builder.Property(p => p.TransferStatusId)
                .IsRequired().HasMaxLength(1)
                .HasComment("The transfer status to be applied.");

            builder.Property(p => p.DateCreated)
                .HasComment("The UTC date when the rule was created.");

            builder.Property(p => p.DateUpdated)
                .HasComment("The UTC date when the rule was updated.");
        }
    }
}

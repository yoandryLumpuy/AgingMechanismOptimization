using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class TransactionStatusChangeConfiguration: IEntityTypeConfiguration<TransactionStatusChange>
    {
        public void Configure(EntityTypeBuilder<TransactionStatusChange> builder)
        {
            throw new NotImplementedException();
        }
    }
}

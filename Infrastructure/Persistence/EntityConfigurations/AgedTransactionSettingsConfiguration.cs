using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class AgedTransactionSettingsConfiguration: IEntityTypeConfiguration<AgedTransactionSettings>
    {
        public void Configure(EntityTypeBuilder<AgedTransactionSettings> builder)
        {
            throw new NotImplementedException();
        }
    }
}

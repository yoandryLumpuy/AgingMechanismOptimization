using Core.Domain;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class AgedTransactionSettingsRepository: Repository<AgedTransactionSettings>, IAgedTransactionSettingsRepository
    {
        public AgedTransactionSettingsRepository(DbContext context) : base(context)
        { }

        public PhoenixContext PhoenixDbContext => DbContextAs<PhoenixContext>()!;
    }
}

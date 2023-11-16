using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Seed
{
    public class AgedTransactionSettingsCustomSeed: ICustomEntitySeed
    {
        public AgedTransactionSettingsCustomSeed(int countToGenerate = 200)
        {
            CountToGenerate = countToGenerate;
        }

        public int CountToGenerate { get; }

        public Task SeedAsync(DbContext dbContext)
        {
            throw new NotImplementedException();
        }
    }
}

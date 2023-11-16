using Core.Domain;
using Infrastructure.Persistence.Seed.Generators;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Seed
{
    public class AgedTransactionSettingsCustomSeed: ICustomEntitySeed
    {
        public AgedTransactionSettingsCustomSeed(int countToGenerate = 50)
        {
            CountToGenerate = countToGenerate;
        }

        public int CountToGenerate { get; }

        public async Task SeedAsync(DbContext dbContext)
        {
            var repository = dbContext.Set<AgedTransactionSettings>();

            await repository.AddRangeAsync(AgedTransactionSettingsFaker.Instance.Generate(CountToGenerate));

            await dbContext.SaveChangesAsync();
        }
    }
}

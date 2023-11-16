using Core.Domain;
using Infrastructure.Persistence.Seed.Generators;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Seed
{
    public class TransactionCustomSeed: ICustomEntitySeed
    {
        public TransactionCustomSeed(int countToGenerate = 1_000_000)
        {
            CountToGenerate = countToGenerate;
        }

        public int CountToGenerate { get; }

        public async Task SeedAsync(DbContext dbContext)
        {
            var repository = dbContext.Set<Transaction>();

            await repository.AddRangeAsync(TransactionFaker.Instance.Generate(CountToGenerate));

            await dbContext.SaveChangesAsync();
        }
    }
}

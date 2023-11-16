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

        public Task SeedAsync(DbContext dbContext)
        {
            throw new NotImplementedException();
        }
    }
}

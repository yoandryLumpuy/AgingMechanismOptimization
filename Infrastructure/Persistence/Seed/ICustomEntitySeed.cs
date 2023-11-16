using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Seed
{
    public interface ICustomEntitySeed
    {
        int CountToGenerate { get; }

        Task SeedAsync(DbContext dbContext);
    }
}

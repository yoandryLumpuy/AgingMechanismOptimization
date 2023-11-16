using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Persistence.Seed
{
    public static class DbContextSeed
    {
        public static async Task Start(PhoenixContext dbContext, bool autoRunMigrations = false)
        {
            if (autoRunMigrations)
            {
                var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Any())
                {
                    await dbContext.Database.MigrateAsync();
                    await dbContext.SaveChangesAsync();
                }
            }

            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace) && type.GetInterfaces().ToList().Exists(i => i == typeof(ICustomEntitySeed)))
                .ToList();

            foreach (var type in types)
            {
                var constructor = type.GetConstructors().FirstOrDefault(
                    c => c.GetParameters().Any(p => p.HasDefaultValue && p.ParameterType == typeof(int)));

                if (constructor == null) continue;

                var instance = constructor.Invoke(new object[] { Type.Missing });

                if (instance is not ICustomEntitySeed customEntitySeed) continue;

                await customEntitySeed.SeedAsync(dbContext);
                await dbContext.SaveChangesAsync();
            }
        }

        public static async Task SeedDataBase(IServiceProvider provider, bool? autoRunMigrations = false)
        {
            using var serviceScope = provider.CreateScope();

            var dbContext = serviceScope?.ServiceProvider?.GetService<PhoenixContext>();

            if (dbContext != null)
            {
                await Start(dbContext, autoRunMigrations ?? false);
            }
        }
    }
}

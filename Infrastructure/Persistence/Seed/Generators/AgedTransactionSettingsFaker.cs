using Bogus;
using Core.Domain;

namespace Infrastructure.Persistence.Seed.Generators
{
    public class AgedTransactionSettingsFaker: Faker<AgedTransactionSettings>
    {
        protected AgedTransactionSettingsFaker()
        {
            RuleFor(i => i.TransferStatusId, f => f.PickRandom<string>(TransferStatusValues.PossibleValues));

            RuleFor(i => i.DateCreated, f => f.Date.Recent(10).ToUniversalTime());

            RuleFor(i => i.DateUpdated, (f, i) => f.Date.Between(i.DateCreated, i.DateCreated.AddDays(10)));

            RuleFor(u => u.LowRange, f => f.Random.Number(1, 100));

            RuleFor(u => u.HighRange, (f, u) => f.Random.Bool(0.2f) ? (int?) null : f.Random.Number(u.LowRange + 1, u.LowRange + 100));
        }

        public static AgedTransactionSettingsFaker Instance => new AgedTransactionSettingsFaker();
    }
}

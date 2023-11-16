using Bogus;
using Core.Domain;

namespace Infrastructure.Persistence.Seed.Generators
{
    public class TransactionFaker: Faker<Transaction>
    {
        protected TransactionFaker()
        {
            RuleFor(i => i.TransferStatusId, f => f.PickRandom<string>(TransferStatusValues.PossibleValues));

            RuleFor(i => i.TransactionNumber, f => f.Random.Guid().ToString());

            RuleFor(i => i.Amount, f => f.Random.Int());

            RuleFor(i => i.Created, f => f.Date.Recent(100));
        }

        public static TransactionFaker Instance => new TransactionFaker();
    }
}

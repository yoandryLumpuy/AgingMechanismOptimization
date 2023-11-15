namespace Core.Domain
{
    public class Transaction : Entity<long>
    {
        public DateTime Created { get; set; }

        public decimal Amount { get; set; }

        public string TransferStatusId { get; set; }

        public string TransactionNumber { get; set; }
    }
}

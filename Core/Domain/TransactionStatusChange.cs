namespace Core.Domain
{
    public class TransactionStatusChange : Entity<long>
    {
        public long TransactionId { get; set; }

        public DateTime ChangeDate { get; set; }

        public string StatusBeforeId { get; set; }

        public string StatusAfterId { get; set; }
    }
}

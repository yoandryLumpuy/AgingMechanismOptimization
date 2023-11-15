namespace Core.Domain
{
    public class AgedTransactionSettings : Entity<int>
    {
        public int LowRange { get; set; }

        public int? HighRange { get; set; }

        public string TransferStatusId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}

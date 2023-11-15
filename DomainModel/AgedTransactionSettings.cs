using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class AgedTransactionSettings : Entity<int>
    {
        public int LowRange { get; set; }

        public int? HighRange { get; set; }

        public string TransferStatusId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}

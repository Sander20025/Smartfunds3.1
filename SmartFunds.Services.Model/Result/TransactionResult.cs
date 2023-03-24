using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFunds.Services.Model.Result
{
    public class TransactionResult
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public required string OrganizationName { get; set; }

        public required string Owner { get; set; }
        public decimal Amount { get; set; }

        public required string Remarks { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}

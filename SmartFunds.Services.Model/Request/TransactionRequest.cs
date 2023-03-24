using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFunds.Services.Model.Request
{
    public class TransactionRequest
    {
        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public required string Owner { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public required string Remarks { get; set; }
    }
}

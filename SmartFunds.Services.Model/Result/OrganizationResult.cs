using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFunds.Services.Model.Result
{
    public class OrganizationResult
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Type { get; set; }

        public required string CompanyNumber { get; set; }

        public string? Email { get; set; }

        public int NumberOfTransactions { get; set; }
    }
}

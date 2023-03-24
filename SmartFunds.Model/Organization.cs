using System.ComponentModel.DataAnnotations.Schema;

namespace SmartFunds.Model
{
    [Table(nameof(Organization))]
    public class Organization
    {
        public int Id { get; set; }
        
        public required string Name { get; set; }
        
        public required string Type { get; set; }
        
        public required string CompanyNumber { get; set; }
        
        public string? Email { get; set; }

        public IList<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}

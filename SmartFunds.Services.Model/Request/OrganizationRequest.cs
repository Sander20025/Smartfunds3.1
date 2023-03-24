using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SmartFunds.Services.Model.Request
{
    public class OrganizationRequest
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        [DisplayName("Type of Company")]
        public required string Type { get; set; }

        [Required]
        [Display(Name = "Company Number")]
        public required string CompanyNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}

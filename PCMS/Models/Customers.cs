using PCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }

        public string? CustomerName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? ContactPerson { get; set; }

        public string? Industry { get; set; }

        public string? Notes { get; set; }

        public int? OrganizationID { get; set; }

        public ICollection<DebtCollection>? Debt { get; set; }

        [ForeignKey("OrganizationID")]
        public Organizations? Organiza_3 { get; set; }

        public ICollection<Receipts>? Recei { get; set; }

        public ICollection<Users>? Usr { get; set; }
    }
}

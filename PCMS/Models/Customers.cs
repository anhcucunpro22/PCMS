using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? ContactPerson { get; set; }

        public string? Industry { get; set; }

        public string? Notes { get; set; }

        public int? OrganizationId { get; set; }

        public  ICollection<DebtCollection> Debt { get; set; } = new List<DebtCollection>();

        public  Organizations? Organiza_3 { get; set; }

        public  ICollection<Receipts> Recei { get; set; } = new List<Receipts>();

        public  ICollection<Users> Usr { get; set; } = new List<Users>();
    }
}

using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class MoneyAccount
    {
        [Key]
        public int AccountID { get; set; }

        public string? AccountName { get; set; }

        public string? AccountType { get; set; }

        public decimal? Balance { get; set; }

        public bool? IsLocked { get; set; }

        public string? Currency { get; set; }

        public string? BankName { get; set; }

        public string? AccountNumber { get; set; }

        public string? ContactPerson { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }

        public string? Notes { get; set; }

        public ICollection<Receipts>? Recei_2 { get; set; }
    }
}

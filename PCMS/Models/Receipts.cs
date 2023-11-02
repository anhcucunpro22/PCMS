using PCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    public class Receipts
    {
        [Key]
        public int ReceiptID { get; set; }

        public int? CustomerID { get; set; }

        public int? AccountID { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public int? ReceiptNumber { get; set; }

        /// <summary>
        /// =sum(TotalAmount) - details
        /// </summary>
        public decimal? AmountReceived { get; set; }

        public decimal? Percentage_discount { get; set; }

        public decimal? Discount_amount { get; set; }

        public decimal? DepositPayment { get; set; }

        public decimal? Percentage_tax { get; set; }

        public decimal? Tax_amount { get; set; }

        /// <summary>
        /// Total_amount = AmountReceived + tax_amount -Discount_amount - DepositPayment
        /// </summary>
        public decimal? Total_amount { get; set; }

        public string? PaymentMethod { get; set; }

        public string? Created_by { get; set; }

        public DateTime? Created_date { get; set; }

        public DateTime? Modified_date { get; set; }

        public string? Notes { get; set; }

        [ForeignKey("AccountID")]
        public MoneyAccount? Acc { get; set; }

        [ForeignKey("CustomerID")]
        public Customers? Ctm_3 { get; set; }

        public ICollection<ReceiptDetail>? ReDetails { get; set; } 
    }
}

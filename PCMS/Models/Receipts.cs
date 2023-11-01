using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class Receipts
    {
        [Key]
        public int ReceiptId { get; set; }

        public int? CustomerId { get; set; }

        public int? AccountId { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public int? ReceiptNumber { get; set; }

        /// <summary>
        /// =sum(TotalAmount) - details
        /// </summary>
        public decimal? AmountReceived { get; set; }

        public decimal? PercentageDiscount { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? DepositPayment { get; set; }

        public decimal? PercentageTax { get; set; }

        public decimal? TaxAmount { get; set; }

        /// <summary>
        /// Total_amount = AmountReceived + tax_amount -Discount_amount - DepositPayment
        /// </summary>
        public decimal? TotalAmount { get; set; }

        public string? PaymentMethod { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? Notes { get; set; }

        public MoneyAccount? Acc { get; set; }

        public Customers? Ctm_3 { get; set; }

        public ICollection<ReceiptDetail> ReDetails { get; set; } = new List<ReceiptDetail>();
    }
}

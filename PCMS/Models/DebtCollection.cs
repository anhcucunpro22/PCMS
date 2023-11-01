using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class DebtCollection
    {
        [Key]
        public int DebtCollectionId { get; set; }

        public int? CustomerId { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public DateTime? CollectionDate { get; set; }

        public decimal? DebtAmount { get; set; }

        public decimal? AmountPaid { get; set; }

        public string? PaymentMethod { get; set; }

        /// <summary>
        /// RemainingAmount = DebtAmount - Amount Paid
        /// </summary>
        public decimal? RemainingAmount { get; set; }

        public string? Notes { get; set; }

        public string? Status { get; set; }

        public DateTime? RecordCreationDate { get; set; }

        public string? CreatedBy { get; set; }

        public Customers? Ctm_2 { get; set; }
    }
}

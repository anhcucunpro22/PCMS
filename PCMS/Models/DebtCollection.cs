using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    public class DebtCollection
    {
        [Key]
        public int DebtCollectionID { get; set; }

        public int? CustomerID { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public DateTime? CollectionDate { get; set; }

        public decimal? DebtAmount { get; set; }

        public decimal? AmountPaid { get; set; }

        public string? PaymentMethod { get; set; }

        /// <summary>
        /// RemainingAmount = DebtAmount - Amount Paid
        /// </summary>
        public decimal? RemainingAmount
        {
            get
            {
                return DebtAmount  - AmountPaid;
            }
            set
            {
                // Không cần thực hiện gì trong phương thức setter
            }
        }

        public string? Notes { get; set; }

        public string? Status { get; set; }

        public DateTime? RecordCreationDate { get; set; }

        public string? CreatedBy { get; set; }

        [ForeignKey("CustomerID")]
        public Customers? Ctm_2 { get; set; }
    }
}

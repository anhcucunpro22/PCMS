using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class ReceiptDetail
    {
        [Key]
        public int ReceiptDetailId { get; set; }

        public int? ReceiptId { get; set; }

        public int? ServiceId { get; set; }

        public int? PhotocopierId { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalAmount { get; set; }

        public Photocopier? Photo_2 { get; set; }

        public Receipts? Recei_3 { get; set; }

        public Service? Ser_2 { get; set; }
    }
}

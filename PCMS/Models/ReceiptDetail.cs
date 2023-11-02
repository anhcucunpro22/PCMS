using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    public class ReceiptDetail
    {
        [Key]
        public int ReceiptDetailID { get; set; }

        public int? ReceiptID { get; set; }

        public int? ServiceID { get; set; }

        public int? PhotocopierID { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalAmount { get; set; }

        [ForeignKey("PhotocopierID")]
        public Photocopier? Photo_2 { get; set; }

        [ForeignKey("ReceiptID")]
        public Receipts? Recei_3 { get; set; }

        [ForeignKey("ServiceID")]
        public Service? Ser_2 { get; set; }
    }
}

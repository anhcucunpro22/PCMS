using PCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    [Table("InventoryIn")]
    public class InventoryIn
    {
        [Key]
        public int InventoryInID { get; set; }

        public int? InvoiceNumber { get; set; }

        public DateTime? InventoryInDate { get; set; }

        public string? ReceivedBy { get; set; }

        public decimal? AmountReceived { get; set; }

        public decimal? Percentage_discount { get; set; }

        public decimal? Discount_amount { get; set; }

        public decimal? Percentage_tax { get; set; }

        public decimal? Tax_amount { get; set; }

        public decimal? Total_amount
        {
            get
            {
                return AmountReceived + Tax_amount - Percentage_discount;
            }
            set
            {
                // Không cần thực hiện gì trong phương thức setter
            }
        }

        public string? PaymentMethod { get; set; }

        public string? Created_by { get; set; }

        public DateTime? Created_date { get; set; }

        public DateTime? Modified_date { get; set; }

        public string? Notes { get; set; }

        public int? WarehouseID { get; set; }

        public int? SupplierID { get; set; }

        public  ICollection<InventoryInDetails>? InvenInDetails { get; set; }


        [ForeignKey("SupplierID")]
        public Suppliers? Suppli { get; set; }

        [ForeignKey("WarehouseID")]

        public  Warehouses? Wahouses_2 { get; set; }
    }
}

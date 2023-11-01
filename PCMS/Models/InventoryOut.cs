using PCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    [Table("InventoryOut")]
    public class InventoryOut
    {
        [Key]
        public int InventoryOutID { get; set; }

        public DateTime? OutDate { get; set; }

        public string? ReceiverName { get; set; }

        public string? ReceiverPhone { get; set; }

        public string? DeliveryMethod { get; set; }

        public decimal? TotalAmount { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public decimal? Percentage_Discount { get; set; }

        public decimal? Discount_Amount { get; set; }

        public decimal? Percentage_Tax { get; set; }

        public decimal? Tax_Amount { get; set; }

        /// <summary>
        /// Tong_tien=AmountReceived+Tax_Amount-Percentage_Discount
        /// </summary>
        public decimal? Tong_tien { get; set; }

        public string? Created_by { get; set; }

        public DateTime? Created_date { get; set; }

        public string? Notes { get; set; }

        public int? OrganizationID { get; set; }

        public int? WarehouseID { get; set; }


        [ForeignKey("OrganizationID")]

        public Organizations? Organiza_2 { get; set; }


        [ForeignKey("WarehouseID")]
        public Warehouses? Wahouses_3 { get; set; }

        public  ICollection<InventoryOutDetails> InvenOutDetails_3 { get; set; } = new List<InventoryOutDetails>();

        
    }
}

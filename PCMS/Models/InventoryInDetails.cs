using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    public class InventoryInDetails
    {
        [Key]
        public int InventoryInDetailID { get; set; }

        public int? InventoryInID { get; set; }

        public int? MaterialID { get; set; }

        public int? UnitOfMeasureID { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }

        [ForeignKey("InventoryInID")]
        public InventoryIn? InvenIn { get; set; }

        [ForeignKey("MaterialID")]
        public Materials? Materials_2 { get; set; }

        [ForeignKey("UnitOfMeasureID")]
        public UnitsOfMeasure? UnitMeasure { get; set; }
    }
}

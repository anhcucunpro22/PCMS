using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    public class InventoryOutDetails
    {
        [Key]
        public int InventoryOutDetailID { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? Notes { get; set; }

        public int? InventoryOutID { get; set; }

        public int? MaterialID { get; set; }

        public int? UnitOfMeasureID { get; set; }

        public int? EquipmentTypeID { get; set; }

        [ForeignKey("EquipmentTypeID")]
        public EquipmentTypes? EquipType_2 { get; set; }

        [ForeignKey("InventoryOutID")]
        public InventoryOut? InvenOuts_4 { get; set; }

        [ForeignKey("MaterialID")]
        public Materials? Materialist_3 { get; set; }

        [ForeignKey("UnitOfMeasureID")]
        public UnitsOfMeasure? UnitMeasure_2 { get; set; }
    }
}

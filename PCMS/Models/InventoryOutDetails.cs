using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class InventoryOutDetails
    {
        [Key]
        public int InventoryOutDetailId { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? Notes { get; set; }

        public int? InventoryOutId { get; set; }

        public int? MaterialId { get; set; }

        public int? UnitOfMeasureId { get; set; }

        public int? EquipmentTypeId { get; set; }

        public EquipmentTypes? EquipType_2 { get; set; }

        public InventoryOut? InvenOuts_4 { get; set; }

        public Materials? Materialist_3 { get; set; }

        public UnitsOfMeasure? UnitMeasure_2 { get; set; }
    }
}

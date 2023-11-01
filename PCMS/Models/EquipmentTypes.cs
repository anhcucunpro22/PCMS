using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class EquipmentTypes
    {
        [Key]
        public int EquipmentTypeId { get; set; }

        public string? TypeName { get; set; }

        public string? Description { get; set; }

        public string? Manufacturer { get; set; }

        public string? Model { get; set; }

        public int? ReleaseYear { get; set; }

        public int? WarrantyMonths { get; set; }

        public decimal? PurchasePrice { get; set; }

        public ICollection<InventoryOutDetails> InvenOutDetails_4 { get; set; } = new List<InventoryOutDetails>();
    }
}

using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class UnitsOfMeasure

    {
        [Key]
        public int UnitOfMeasureID { get; set; }

        public string? UnitName { get; set; }

        public string? Abbreviation { get; set; }

        public string? Description { get; set; }

        public decimal? ConversionFactor { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<InventoryInDetails>? InvenInDetails_2 { get; set; }

        public ICollection<InventoryOutDetails>? InvenOutDetails_2 { get; set; }
    }
}

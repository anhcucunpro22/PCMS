using PCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    [Table("Warehouses")]
    public class Warehouses
    {
        [Key]
        public int WarehouseID { get; set; }

        public string? WarehouseName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? ManagerNameWh { get; set; }

        public int? FacilityID { get; set; }


        [ForeignKey("FacilityID")]

        public TrainingFacilities? Facility { get; set; }

        public  ICollection<InventoryIn>? InvenIns { get; set; } 

        public  ICollection<InventoryOut>? InvenOuts { get; set; } 
    }
}

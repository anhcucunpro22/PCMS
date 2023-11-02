using PCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    public class Photocopier
    {
        [Key]
        public int PhotocopierID { get; set; }

        public string? Manufacturer { get; set; }

        public string? Model { get; set; }

        public int? ReleaseYear { get; set; }

        public int? WarrantyMonths { get; set; }

        public string? SerialNumber { get; set; }

        public string? Location { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public decimal? PurchasePrice { get; set; }

        public bool? IsActive { get; set; }

        public int? FacilityID { get; set; }

        [ForeignKey("FacilityID")]
        public TrainingFacilities? Facility_2 { get; set; }

        public ICollection<ReceiptDetail>? ReDetails_3 { get; set; } 
    }
}

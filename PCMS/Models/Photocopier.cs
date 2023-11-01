using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class Photocopier
    {
        [Key]
        public int PhotocopierId { get; set; }

        public string? Manufacturer { get; set; }

        public string? Model { get; set; }

        public int? ReleaseYear { get; set; }

        public int? WarrantyMonths { get; set; }

        public string? SerialNumber { get; set; }

        public string? Location { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public decimal? PurchasePrice { get; set; }

        public bool? IsActive { get; set; }

        public int? FacilityId { get; set; }

        public TrainingFacilities? Facility_2 { get; set; }

        public ICollection<ReceiptDetail> ReDetails_3 { get; set; } = new List<ReceiptDetail>();
    }
}

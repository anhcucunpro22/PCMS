using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class TrainingFacilities
    {
        [Key]
        public int FacilityId { get; set; }

        public string? FacilityName { get; set; }

        public string? Address { get; set; }

        public string? ContactName { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }

        public string? Website { get; set; }

        public  ICollection<Photocopier>? Photo { get; set; } 

        public  ICollection<RoleFacilities>? RoleFaci { get; set; } 

        public  ICollection<Warehouses>? Wahouses { get; set; }
    }
}

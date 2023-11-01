using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class RoleFacilities
    {
        [Key]
        public int RoleFacilitiesId { get; set; }

        public int? RoleId { get; set; }

        public int? FacilityId { get; set; }

        public  TrainingFacilities? Facility_3 { get; set; }

        public Role? Rl_3 { get; set; }
    }
}

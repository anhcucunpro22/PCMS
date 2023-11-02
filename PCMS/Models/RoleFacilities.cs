using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    public class RoleFacilities
    {
        [Key]
        public int RoleFacilitiesID { get; set; }

        public int? RoleID { get; set; }

        public int? FacilityID { get; set; }

        [ForeignKey("FacilityID")]
        public  TrainingFacilities? Facility_3 { get; set; }

        [ForeignKey("RoleID")]
        public Role? Rl_3 { get; set; }
    }
}

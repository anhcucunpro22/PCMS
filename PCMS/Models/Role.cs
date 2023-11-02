using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        public string? RoleName { get; set; }

        public string? Description { get; set; }

        public ICollection<RoleFacilities>? RFacilities { get; set; }

        public ICollection<RoleFunction>? RFunctions_2 { get; set; }

        public ICollection<UsersRole>? URoles_2 { get; set; } 
    }
}

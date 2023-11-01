using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        public string? RoleName { get; set; }

        public string? Description { get; set; }

        public ICollection<RoleFacilities> RFacilities { get; set; } = new List<RoleFacilities>();

        public ICollection<RoleFunction> RFunctions_2 { get; set; } = new List<RoleFunction>();

        public ICollection<UsersRole> URoles_2 { get; set; } = new List<UsersRole>();
    }
}

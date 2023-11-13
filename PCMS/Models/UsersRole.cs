using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    public class UsersRole
    {
        [Key]
        public int UsersRoleID { get; set; }

        public int UserID { get; set; }

        public int RoleID { get; set; }

        [ForeignKey("RoleID")]
        public Role? Rl_2 { get; set; }

        [ForeignKey("UserID")]
        public Users? Usr_2 { get; set; }
    }
}

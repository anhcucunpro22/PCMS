using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class UsersRole
    {
        [Key]
        public int UsersRoleId { get; set; }

        public int? UserId { get; set; }

        public int? RoleId { get; set; }

        public Role? Rl_2 { get; set; }

        public Users? Usr_2 { get; set; }
    }
}

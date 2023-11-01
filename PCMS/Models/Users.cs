using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Notes { get; set; }

        public bool? Isactive { get; set; }

        public int? CustomerId { get; set; }

        public  Customers? Ctm_4 { get; set; }

        public  ICollection<UsersRole> URoles { get; set; } = new List<UsersRole>();
    }
}

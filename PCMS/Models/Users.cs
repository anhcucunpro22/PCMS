using PCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        public string? UserName { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Notes { get; set; }

        public bool? Isactive { get; set; }

        public int? CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public  Customers? Ctm_4 { get; set; }

        public  ICollection<UsersRole>? URoles { get; set; }
    }
}

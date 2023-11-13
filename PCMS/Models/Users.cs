using PCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace PCMS.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; } 

        public string UserName { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }

        public bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputPassword));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash == hashedPassword;
            }
        }
        public string? Notes { get; set; } = string.Empty;

        public bool? Isactive { get; set; } 

        public int? CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public  Customers? Ctm_4 { get; set; }

        public  ICollection<UsersRole>? URoles { get; set; }
    }
}

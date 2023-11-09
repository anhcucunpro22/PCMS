using System.Security.Cryptography;
using System.Text;

namespace PCMS.AppModels
{
    public class UserModel
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public string? Designation { get; set; }
        public string? UserMessage { get; set; }
        public string? AccessToken { get; set; }
        public DateTime CreatedDate { get; set; }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}

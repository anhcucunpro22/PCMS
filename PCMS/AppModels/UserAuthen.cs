//using System.Security.Cryptography;
//using System.Text;

//namespace PCMS.AppModels
//{
//    public class UserAuthen
//    {
//        public int ID { get; set; }
//        public string? FullName { get; set; } = string.Empty;
//        public string? UserName { get; set; } = string.Empty;
//        public string? EmailId { get; set; } = string.Empty;
//        public string? Password { get; set; }= string.Empty;
//        public string? Notes { get; set; } = string.Empty;
//        public DateTime CreatedDate { get; set; }

//        internal string? UserMessage;

//        public string HashPassword(string password)
//        {
//            using (var sha256 = SHA256.Create())
//            {
//                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
//                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
//                return hash;
//            }
//        }
//    }
//}

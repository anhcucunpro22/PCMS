using PCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    [Table("Schools")]
    public class Schools
    {
        [Key]
        public int SchoolID { get; set; }

        public string? SchoolName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? PrincipalName { get; set; }

        public string? Email { get; set; }

        public ICollection<Organizations>? Organiza { get; set; }
    }
}

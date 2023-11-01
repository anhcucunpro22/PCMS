using PCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    [Table("Organizations")]
    public class Organizations
    {
        [Key]
        public int OrganizationID { get; set; }

        public string? OrganizationName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? ContactPerson { get; set; }

        public string? Email { get; set; }

        public int? SchoolID { get; set; }

        [ForeignKey("SchoolID")]
        public Schools? Sch { get; set; }

        public ICollection<Customers>? Ctm { get; set; } 

        public  ICollection<InventoryOut>? InvenOuts_3 { get; set; }

        
    }
}

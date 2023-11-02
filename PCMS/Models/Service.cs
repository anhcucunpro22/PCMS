using PCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }

        public int? ServiceGroupID { get; set; }

        public string? ServiceName { get; set; }

        public string? Description { get; set; }

        public string? ServiceCategory { get; set; }

        public decimal? Price { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<ReceiptDetail>? ReDetails_2 { get; set; }

        [ForeignKey("ServiceGroupID")]
        public ServiceGroups? SerGroup { get; set; }
    }
}

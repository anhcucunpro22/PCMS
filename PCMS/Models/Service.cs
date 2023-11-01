using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        public int? ServiceGroupId { get; set; }

        public string? ServiceName { get; set; }

        public string? Description { get; set; }

        public string? ServiceCategory { get; set; }

        public decimal? Price { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<ReceiptDetail> ReDetails_2 { get; set; } = new List<ReceiptDetail>();

        public ServiceGroups? SerGroup { get; set; }
    }
}

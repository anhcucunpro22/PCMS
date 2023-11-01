using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class ServiceGroups
    {
        [Key]
        public int ServiceGroupId { get; set; }

        public string? GroupName { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<Service> Ser { get; set; } = new List<Service>();
    }
}

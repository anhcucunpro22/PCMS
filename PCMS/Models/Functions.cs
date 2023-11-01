using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class Functions
    {
        [Key]
        public int FunctionId { get; set; }

        public string? FunctionName { get; set; }

        public string? Description { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<RoleFunction> RFunctions { get; set; } = new List<RoleFunction>();
    }
}

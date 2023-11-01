using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class RoleFunction
    {
        [Key]
        public int RoleFunctionId { get; set; }

        public int? RoleId { get; set; }

        public int? FunctionId { get; set; }

        public virtual Functions? Func { get; set; }

        public virtual Role? Rl { get; set; }
    }
}

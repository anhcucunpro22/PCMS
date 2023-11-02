using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCMS.Models
{
    public class RoleFunction
    {
        [Key]
        public int RoleFunctionID { get; set; }

        public int? RoleID { get; set; }

        public int? FunctionID { get; set; }

        [ForeignKey("FunctionID")]
        public  Functions? Func { get; set; }

        [ForeignKey("RoleID")]
        public  Role? Rl { get; set; }
    }
}

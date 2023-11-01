using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PCMS.Models
{
    [Table("Material_Group")]
    public class MaterialGroup
    {
        [Key]
        public int MaterialGroupID { get; set; }

        public string? MaterialGroupName { get; set; }

        public string? Description { get; set; }
        public ICollection<Materials>? Materialist { get; set; }
    }
}

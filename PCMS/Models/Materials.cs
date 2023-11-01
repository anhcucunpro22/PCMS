using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PCMS.Models;


namespace PCMS.Models
{
    [Table("Materials")]
    public class Materials
    {
        [Key]
        public int MaterialID { get; set; }

        public int MaterialGroupID { get; set; }

        public string? MaterialName { get; set; }

        public ICollection<InventoryInDetails>? InvenInDetails { get; set; } = new List <InventoryInDetails>();
        public ICollection<InventoryOutDetails>? InvenOutDetails { get; set; } = new List<InventoryOutDetails>();

        [ForeignKey("MaterialGroupID")]
        public MaterialGroup? MaterialGroup_1 { get; set; }

    }
}

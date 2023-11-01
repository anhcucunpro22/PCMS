using PCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace PCMS.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }

        public string? SupplierName { get; set; }

        public string? ContactName { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }

        public string? Address { get; set; }

        public  ICollection<InventoryIn>? InvenIns_2 { get; set; } 
    }
}

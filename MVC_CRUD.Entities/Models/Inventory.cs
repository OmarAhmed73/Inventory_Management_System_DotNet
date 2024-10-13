using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CRUD.Entities.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        public int ProductUpdated { get; set; }

        public DateTime? LastUpdated { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

    }
}

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CRUD.Entities.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        public string? InventoryName { get; set; }

        public DateTime LastUpdated { get; set; }

        public int ProductAmount { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product? product { get; set; }
        [NotMapped]
        public List<Product> ProductList { get; set; }


    }
}

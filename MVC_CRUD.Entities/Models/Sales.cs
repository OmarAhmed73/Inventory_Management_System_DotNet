using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Entities.Models
{
    public class Sales
    {
        [Key]
        public int SalesId { get; set; }
        public string? Name { get; set; }
        public int AmountSaled { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product? product { get; set; }
        [NotMapped]
        public List<Product> ProductList { get; set; }
    }
}

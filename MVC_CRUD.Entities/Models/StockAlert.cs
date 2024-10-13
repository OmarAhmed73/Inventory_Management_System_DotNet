using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CRUD.Entities.Models
{
    public class StockAlert
    {
        [Key]
        public int StockId { get; set; }
        public string Status { get; set; }

        public DateTime AlertDate { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}

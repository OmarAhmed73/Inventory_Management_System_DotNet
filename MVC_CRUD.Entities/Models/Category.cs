using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Entities.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

    }
}

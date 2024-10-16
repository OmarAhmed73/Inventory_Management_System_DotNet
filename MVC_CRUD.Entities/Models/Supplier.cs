using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CRUD.Entities.Models
{
	public class Supplier
	{
		[Key]
		public int SupplierID { get; set; }
		public string SupplierName { get; set; }
		public string SupplierContact { get; set; }
		[NotMapped]
		public IEnumerable<Product>? Products { get; set; }

	}
}

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CRUD.Entities.Models
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }
		[Display(Name = "Product Name")]
		public string ProductName { get; set; }
		[Display(Name = "Product Description")]
		public string ProductDescription { get; set; }

		[Display(Name = "Reorder Level")]
		public int ReorderLevel { get; set; }
		public double Discount { get; set; } = 0;
		public double Price { get; set; }
		[ForeignKey(nameof(Category))]
		[Display(Name = "Category Name")]
		public int CategoryId { get; set; }
		public Category? category { get; set; }
		[NotMapped]
		public List<Category> CategoryList { get; set; }

		[ForeignKey(nameof(Supplier))]
		[Display(Name = "Supplier Name")]
		public int SupplierId { get; set; }
		public Supplier? supplier { get; set; }
		[NotMapped]
		public List<Supplier> SupplierList { get; set; }

		[StringLength(250)]
		public string? Picture { get; set; }

		[NotMapped]
		public IFormFile? ImageFile { get; set; }

	}
}

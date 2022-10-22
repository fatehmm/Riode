using System;
namespace Riode.Models
{
	public class ProductImage
	{
		public ProductImage()
		{
		}
		public int Id { get; set; }
		public string ImageUrl { get; set; }
		public bool? Status { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}


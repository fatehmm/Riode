using System;
namespace Riode.Models
{
	public class ProductBadge
	{
		public ProductBadge()
		{
		}
		public int Id { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }

		public int BadgeId { get; set; }
		public Badge Badge { get; set; }



	}
}


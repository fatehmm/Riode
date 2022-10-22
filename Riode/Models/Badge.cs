using System;
namespace Riode.Models
{
	public class Badge
	{
		public Badge()
		{
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public ICollection<ProductBadge> ProductBadges { get; set; }
	}
}


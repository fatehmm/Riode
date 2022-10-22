using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riode.Models
{
	public class Product : BaseEntity
	{
		public Product()
		{
		}
        [Required]
        public string Name { get; set; }
        public int? ReviewSum { get; set; } = 0;
        public int? ReviewCount { get; set; } = 0;
        [Required]
        public decimal InitialPrice { get; set; }
        
        public decimal SellPrice { get; set; }
        [Range(0, 100)]
        public int DiscountPercent { get; set; }
        public string? SubTitle { get; set; }
        [Required]
        public int StockCount { get; set; }
        public string? Description { get; set; }
        public int? BadgeId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int BrandId { get; set; }
        public bool IsDeleted { get; set; }


        public Brand? Brand { get; set; }
        public Category? Category { get; set; }
        public Badge? Badge { get; set; }
        public ICollection<ProductBadge> ProductBadges { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }



        [NotMapped]
        public List<int> ImageIds { get; set; }
        [NotMapped]
        public List<int> TagIds { get; set; }

        [NotMapped]
        public IFormFile? MainImage { get; set; }
        [NotMapped]
        public IFormFile? HoverImage { get; set; }
        [NotMapped]
        public IFormFileCollection? Images { get; set; }
    }
}


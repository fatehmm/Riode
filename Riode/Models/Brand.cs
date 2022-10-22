using System;
using System.ComponentModel.DataAnnotations;

namespace Riode.Models
{
	public class Brand : BaseEntity
	{
		public Brand()
		{
		}

        [StringLength(45), Required]
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}


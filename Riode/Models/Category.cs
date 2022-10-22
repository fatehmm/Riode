using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riode.Models
{
	public class Category : BaseEntity
	{
		public Category()
		{
		}

		[StringLength(50, ErrorMessage = "The category length cannot exceed 50 characters. Try it again."), Required(ErrorMessage = "The Category name is required. Please type it.")]
		public string Name { get; set; }
		public string? ImageUrl { get; set; }
		public ICollection<Product>? Products { get; set; }
		[NotMapped]
		public IFormFile? ImageFile { get; set; }
		public bool IsDeleted { get; set; }

	}
}


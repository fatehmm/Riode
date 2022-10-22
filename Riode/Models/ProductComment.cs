using System;
using System.ComponentModel.DataAnnotations;

namespace Riode.Models
{
	public class ProductComment : BaseEntity
	{
		public ProductComment()
		{
		}
		[StringLength(20, ErrorMessage = "The title length cannot exceed 20 characters. Try it again."), Required(ErrorMessage = "The title is required. Please type it.")]
		public string TitleComment { get; set; }
		[StringLength(250, ErrorMessage = "Body cannot exceed 250 characters. Try it again!") , Required(ErrorMessage = "Body of the comment is required. Please type it.")]
		public string BodyComment { get; set; }

		// App useri buraya deploy ele! - one to many relationship
		// Review deploy ele - one to many relationship

	}
}


using System;
using System.ComponentModel.DataAnnotations;

namespace Riode.Models
{
	public class Review : BaseEntity
	{
		public Review()
		{
		}
		[Range(0, 5)]
		public int ReviewAmount { get; set; }
	}
}


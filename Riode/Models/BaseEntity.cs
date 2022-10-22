using System;
namespace Riode.Models
{
	public class BaseEntity
	{
		public BaseEntity()
		{
		}
		public int Id { get; set; }
		public DateTime? ModifyDate { get; set; }
		public DateTime? CreatedDate { get; set; }

	}
}


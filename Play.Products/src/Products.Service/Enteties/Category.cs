using System;
using System.ComponentModel.DataAnnotations;

namespace Play.Products.Service.Enteties
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public string Image { get; set; }
		[Required]
		public int DisplayOrder { get; set; }
		[Required]
		public bool IsDeleted { get; set; }
	}
}

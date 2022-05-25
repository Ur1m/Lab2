using System;
using System.ComponentModel.DataAnnotations;

namespace Play.Products.Service.Enteties
{
	public class Category
	{
		
		public int CategoryId { get; set; }
		
		public string Name { get; set; }
		
		public string Description { get; set; }
	
		public string Image { get; set; }
		
		public int DisplayOrder { get; set; }
	
		public bool IsDeleted { get; set; }
	}
}

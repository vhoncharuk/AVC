
using System.Collections.Generic;

namespace AVC
{
	public class Menu
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public int? SubCategory { get; set; }
		public List<Menu> List { get; set; }
	}
}
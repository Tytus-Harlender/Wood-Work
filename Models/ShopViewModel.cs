using WoodWorks.Data.Entities;

namespace WoodWorks.Models
{
	public class ShopViewModel
	{
		public IEnumerable<OrderItem> OrderItems { get; set; }
		public IEnumerable<Product> Products { get; set; }
	}
}

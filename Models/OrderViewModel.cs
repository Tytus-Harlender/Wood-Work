using WoodWorks.Data.Entities;

namespace WoodWorks.Models
{
	public class OrderViewModel
	{
		public ICollection<OrderItemViewModel>? Items { get; set; }
	}
}

namespace WoodWorks.Data.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public ICollection<OrderItem>? Items { get; set; }
	}
}

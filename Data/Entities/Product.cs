namespace WoodWorks.Data.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Category { get; set; }
		public string? Size { get; set; }
		public decimal? Price { get; set; }
		public string? PhotoId { get; set; }
		public bool? IsInStock { get; set; }
		public string? Description { get; set; }
	}
}

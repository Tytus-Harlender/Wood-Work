using WoodWorks.Data.Entities;

namespace WoodWorks.Services
{
	public class ShoppingCartService : IShoppingCartService
	{
		public string? ShoppingCartId { get; set; }
		public List<OrderItem> ShoppingCartItems { get; set; } = default!;

        public ShoppingCartService()
        {
			InitializeItemsList();
		}

		private void InitializeItemsList()
		{
			if (ShoppingCartItems == null)
			{
				ShoppingCartItems = new List<OrderItem>();
			}
		}

        public void AddToCart(OrderItem item)
		{
			if (item != null)
			{
				if (ShoppingCartItems.Find(i => i.ProductId == item.ProductId) != null)
				{
					ShoppingCartItems.Find(i => i.ProductId == item.ProductId).Quantity++;
				}
				else
				{
					ShoppingCartItems.Add(item);
				}
			}
		}

		public void ClearCart()
		{
			ShoppingCartItems = new List<OrderItem>();
		}

		public List<OrderItem> GetShoppingCartItems()
		{
			return ShoppingCartItems;
		}

		public decimal GetShoppingCartTotal()
		{
			throw new NotImplementedException();
		}

		public int RemoveFromCart(OrderItem item)
		{
			throw new NotImplementedException();
		}
	}
}

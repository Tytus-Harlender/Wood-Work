using WoodWorks.Data.Entities;

namespace WoodWorks.Services
{
	public interface IShoppingCartService
	{
		void AddToCart(OrderItem item);
		int RemoveFromCart(OrderItem item);
		List<OrderItem> GetShoppingCartItems();
		void ClearCart();
		decimal GetShoppingCartTotal();
		List<OrderItem> ShoppingCartItems { get; set; }
	}
}

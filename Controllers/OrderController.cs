using Microsoft.AspNetCore.Mvc;
using WoodWorks.Data;
using WoodWorks.Data.Entities;
using WoodWorks.Services;

namespace WoodWorks.Controllers
{
	public class OrderController : Controller
	{
		private Order? _currentOrder { get; set; }
		private readonly IWoodWorkRepository _woodWorkRepository;
		private readonly IShoppingCartService _shoppingCartService;

		public OrderController(IWoodWorkRepository woodWorkRepository, IShoppingCartService shoppingCartService)
		{
			_woodWorkRepository = woodWorkRepository;
			_shoppingCartService = shoppingCartService;
		}

		[Route("/{productId:int}")]
		public RedirectResult AddItemToOrder([FromRoute]int productId)
		{
			var selectedProduct = _woodWorkRepository.GetProductById(productId);
			var additionalItem = new OrderItem()
			{
				ProductId = productId,
				Quantity = 1,
				UnitPrice = (decimal)selectedProduct.Price
			};
			_shoppingCartService.AddToCart(additionalItem);

			return Redirect("App/Shop"); 
		}

		public RedirectToActionResult PlaceOrder()
		{
			var currentOrder = new Order() {
				Items = _shoppingCartService.GetShoppingCartItems(),
				OrderDate = DateTime.UtcNow
			};
			if (_currentOrder != null || _currentOrder?.Items == null)
			{
				_woodWorkRepository.AddOrder(currentOrder);
			}
			_shoppingCartService.ClearCart();
			return RedirectToAction("OrderPlacedSuccessfully"); 
		}

		public IActionResult OrderPlacedSuccessfully()
		{
			return View();
		}
	}
}

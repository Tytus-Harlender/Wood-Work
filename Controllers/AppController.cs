using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WoodWorks.Data;
using WoodWorks.Models;
using WoodWorks.Services;

namespace WoodWorks.Controllers
{
	public class AppController : Controller
	{
		private readonly IWoodWorkRepository _woodWorkRepository;
		private readonly IShoppingCartService _shoppingCartService;

		public AppController(IWoodWorkRepository woodWorkRepository, IShoppingCartService shoppingCartService)
		{
			_woodWorkRepository = woodWorkRepository;
			_shoppingCartService = shoppingCartService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Shop()
		{
			var products = _woodWorkRepository.GetAllProducts().ToList();
			var currentCartItems = _shoppingCartService.GetShoppingCartItems();
			foreach (var item in currentCartItems)
			{
				item.Product = _woodWorkRepository.GetProductById(item.ProductId);
			}
			var shopViewModel = new ShopViewModel();
			shopViewModel.OrderItems = currentCartItems;
			shopViewModel.Products = products;
			return View(shopViewModel);
		}

		[HttpPost]
		public IActionResult Shop(ShopViewModel shopViewModel)
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
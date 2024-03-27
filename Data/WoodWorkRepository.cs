using WoodWorks.Data.Entities;
using WoodWorks.Models;

namespace WoodWorks.Data
{
	public class WoodWorkRepository : IWoodWorkRepository
	{
		private readonly ILogger _logger;
		private readonly WoodWorkContext _ctx;
		public WoodWorkRepository(ILogger<WoodWorkRepository> logger, WoodWorkContext ctx)
		{
			_logger = logger;
			_ctx = ctx;
		}

		public IEnumerable<Product> GetAllProducts()
		{
			try
			{
				_logger.LogInformation("GetAllProducts has been called");
				return _ctx.Products.OrderBy(p => p.Name).ToList();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Failed to get all products via the EF Context: {ex}");
				return null;
			}
		}

		public Product GetProductById(int id)
		{
			try
			{
				_logger.LogInformation("GetProductById has been called");
				return _ctx.Products.Find(id);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Failed to get product by Id via the EF Context: {ex}");
				return null;
			}
		}

		public void AddOrder(Order order)
		{
			try
			{
				_logger.LogInformation("AddOrder has been called");
				_ctx.Add(order);
				_ctx.SaveChanges();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Failed to save the order via the EF Context: {ex}");
			}
		}
	}
}

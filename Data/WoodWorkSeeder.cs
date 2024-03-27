using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WoodWorks.Data.Entities;

namespace WoodWorks.Data
{
	public class WoodWorkSeeder : IWoodWorkSeeder
	{
		private readonly WoodWorkContext _ctx;
		private readonly IWebHostEnvironment _env;
		private readonly ILogger<WoodWorkSeeder> _logger;

		public WoodWorkSeeder(WoodWorkContext ctx, IWebHostEnvironment env, ILogger<WoodWorkSeeder> logger)
		{
			_ctx = ctx;
			_env = env;
			_logger = logger;
		}

		public void SeedData()
		{
			using (_ctx)
			{
				try
				{
					_ctx.Database.Migrate();

					if (!_ctx.Products.Any())
					{
						// Need to create the Sample Data
						var file = Path.Combine(_env.ContentRootPath, "Data/seedingData.json");
						var json = File.ReadAllText(file);
						var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);
						_ctx.Products.AddRange(products);
						_ctx.SaveChanges();
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, $"Seeding the database has failed: {ex}");
					throw;
				}
			}
		}
	}
}

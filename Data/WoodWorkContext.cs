using Microsoft.EntityFrameworkCore;
using WoodWorks.Data.Entities;

namespace WoodWorks.Data
{
	public class WoodWorkContext : DbContext
	{
		public WoodWorkContext()
		{

		}

		public WoodWorkContext(DbContextOptions<WoodWorkContext> options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; }

		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal").HasPrecision(18,2);
			modelBuilder.Entity<OrderItem>().Property(p => p.UnitPrice).HasColumnType("decimal").HasPrecision(18, 2);
			base.OnModelCreating(modelBuilder);
		}
	}
}

using WoodWorks.Data.Entities;

namespace WoodWorks.Data
{
	public interface IWoodWorkRepository
	{
		IEnumerable<Product> GetAllProducts();

		Product GetProductById(int id);

		void AddOrder(Order order);

	}
}

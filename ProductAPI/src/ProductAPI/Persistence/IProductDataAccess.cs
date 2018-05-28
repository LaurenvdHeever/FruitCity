using ProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Persistence
{
	public interface IProductDataAccess
	{
		/// <summary>
		///   Retrieves a list of products.
		/// </summary>   
		/// <returns></returns>
		Task<IEnumerable<Product>> GetProductsAsync();

		/// <summary>
		///   Retrieves a product.
		/// </summary>   
		/// <returns></returns>
		Task<Product> GetProductAsync(int productId);

		/// <summary>
		///   Retrieves the details related to a product.
		/// </summary>   
		/// <param name="productId"></param>
		/// <returns></returns>
		Task<Restriction> GetProductRestrictionsAsync(int productId);

		/// <summary>
		///   Retrieves the details related to a product.
		/// </summary>   
		/// <param name="productId"></param>
		/// <returns></returns>
		Task<Special> GetProductSpecialsAsync(int productId);
	}
}

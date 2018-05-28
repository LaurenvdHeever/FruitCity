using ProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Persistence
{
	public interface ICartDataAccess
	{
		/// <summary>
		///   Adds items to the cart.
		/// </summary>   
		/// <returns></returns>
		Task AddCartItemAsync(int productId);

		/// <summary>
		///   Removes an item from the cart.
		/// </summary>   	
		/// <returns></returns>
		Task RemoveCartItemAsync(int productId);

		/// <summary>
		///   Updates the product details in the cart.
		/// </summary>   
		/// <returns></returns>
		Task UpdateCartItemAsync(int productId, int quantity);

		/// <summary>
		///   Retrieves the details related to a product.
		/// </summary>   
		/// <param name="productId"></param>
		/// <returns></returns>
		Task<Restriction> GetProductRestrictionsAsync(int productId);

		/// <summary>
		///   Retrieves all items from the cart.
		/// </summary>   		
		/// <returns></returns>
		Task<IEnumerable<CartItem>> GetCartAsync();
	}
}

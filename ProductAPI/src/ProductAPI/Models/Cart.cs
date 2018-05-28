using System.Collections.Generic;

namespace ProductAPI.Models
{
	public class Cart
	{
		/// <summary>
		///   The total price of the all the items for the product.
		/// </summary>
		public int TotalCartPrice { get; set; }

		/// <summary>
		///   The list of items in the cart.
		/// </summary>
		public IEnumerable<CartItem> CartItems { get; set; }
	}
}
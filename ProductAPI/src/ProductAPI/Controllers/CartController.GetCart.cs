using ProductAPI.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;

namespace ProductAPI.Controllers
{
	public partial class CartController
	{
		/// <summary>
		/// Returns the details for a specific product.
		/// </summary>		
		/// <returns></returns>
		[HttpGet]
		[Route()]
		[ResponseType(typeof(Cart))]
		public async Task<IHttpActionResult> GetCart()
		{
			var cartItems = await _dataAccess.GetCartAsync().ConfigureAwait(false);

			var cart = new Cart
			{
				TotalCartPrice = CalculateCartPrice(cartItems),
				CartItems = cartItems
			};				

			return Ok(cart);
		}

		private int CalculateCartPrice(IEnumerable<CartItem> cartItems)
		{
			var totalCartPrice = 0;

			foreach (var item in cartItems)
			{
				totalCartPrice = totalCartPrice + item.TotalItemPrice;
			}

			return totalCartPrice;
		}
	}
}
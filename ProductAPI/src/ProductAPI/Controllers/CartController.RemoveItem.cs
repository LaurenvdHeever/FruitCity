using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProductAPI.Controllers
{
	public partial class CartController
	{
		/// <summary>
		/// Returns the details for a specific product.
		/// </summary>
		/// <param name="productId">The product Id used to indentify the product.</param>		
		/// <returns></returns>
		[HttpPost]
		[Route("remove/productId/{productId:int}")]
		[ResponseType(typeof(bool))]
		public async Task<IHttpActionResult> RemoveCartItem(int productId)
		{
			await _dataAccess.RemoveCartItemAsync(productId).ConfigureAwait(false);			

			return Ok();
		}
	}
}
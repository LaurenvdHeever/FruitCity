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
		/// <returns></returns>
		[HttpPost]
		[Route("update/productId/{productId:int}/quantity/{quantity:int}")]
		[ResponseType(typeof(bool))]
		public async Task<IHttpActionResult> UpdateCartItem(int productId, int quantity)
		{
			//first check for restrictions
			var productRestrictions = await _dataAccess.GetProductRestrictionsAsync(productId).ConfigureAwait(false);

			if (quantity == 0 || productRestrictions != null && quantity > productRestrictions.RestrictionQuantity)
			{
				throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
			}

			await _dataAccess.UpdateCartItemAsync(productId, quantity).ConfigureAwait(false);

			return Ok();
		}
	}
}
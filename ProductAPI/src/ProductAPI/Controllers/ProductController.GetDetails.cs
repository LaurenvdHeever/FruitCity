using ProductAPI.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProductAPI.Controllers
{
	public partial class ProductController
	{
		/// <summary>
		/// Returns the details for a specific product.
		/// </summary>
		/// <param name="productId">The product Id used to indentify the product.</param>		
		/// <returns></returns>
		[HttpGet]
		[Route("details/productId/{productId:int}")]
		[ResponseType(typeof(ProductDetails))]
		public async Task<IHttpActionResult> GetProductDetails(int productId)
		{
			var product = await _dataAccess.GetProductAsync(productId).ConfigureAwait(false);

			var productRestrictions = await _dataAccess.GetProductRestrictionsAsync(productId).ConfigureAwait(false);

			var productSpecials = await _dataAccess.GetProductSpecialsAsync(productId).ConfigureAwait(false);

			var productDetails = new ProductDetails
			{
				Product = product,
				Restriction = productRestrictions,			
				Special = productSpecials			
			};

			return Ok(productDetails);
		}
	}
}
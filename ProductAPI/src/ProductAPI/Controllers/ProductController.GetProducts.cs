using ProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProductAPI.Controllers
{
	public partial class ProductController
	{
		/// <summary>
		/// Returns a list of products.
		/// </summary>		
		/// <returns></returns>
		[HttpGet]
		[Route("products")]
		[ResponseType(typeof(IEnumerable<Product>))]
		public async Task<IHttpActionResult> GetProducts()
		{
			var products = await _dataAccess.GetProductsAsync().ConfigureAwait(false);

			return Ok(products);
		}
	}
}
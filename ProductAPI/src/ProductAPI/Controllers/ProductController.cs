using ProductAPI.Persistence;
using System.Web.Http;

namespace ProductAPI.Controllers
{
	/// <summary>
	///   Used to represent a product details and allow for related activities.
	/// </summary>
	[RoutePrefix("product")]
	public partial class ProductController : ApiController
	{
		private readonly IProductDataAccess _dataAccess;

		/// <summary>
		/// </summary>
		/// <param name="dataAccess"></param>
		public ProductController(IProductDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}
	}
}

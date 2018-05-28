using ProductAPI.Persistence;
using System.Web.Http;

namespace ProductAPI.Controllers
{
	/// <summary>
	///   Used to represent the cart details.
	/// </summary>
	[RoutePrefix("cart")]
	public partial class CartController : ApiController
	{
		private readonly ICartDataAccess _dataAccess;

		/// <summary>
		/// </summary>
		/// <param name="dataAccess"></param>
		public CartController(ICartDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}
	}
}

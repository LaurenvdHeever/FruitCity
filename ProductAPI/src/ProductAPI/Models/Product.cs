namespace ProductAPI.Models
{
	public class Product
	{
		/// <summary>
		///   The productId of the product.
		/// </summary>
		public int ProductId { get; set; }

		/// <summary>
		///   The name of the product.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		///   The description of the product.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		///   The price of the product.
		/// </summary>
		public int Price { get; set; }

		/// <summary>
		///   The currency value if the price of the product.
		/// </summary>
		public string CurrencyCode { get; set; }
	}
}
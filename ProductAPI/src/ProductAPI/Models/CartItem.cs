namespace ProductAPI.Models
{
	public class CartItem
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
		///   The item amount of the product in the cart.
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		///   The price of the product.
		/// </summary>
		public int ItemPrice { get; set; }

		/// <summary>
		///   The discount received if there is a special.
		/// </summary>
		public int Discount { get; set; }

		/// <summary>
		///   The total price of the all the items for the product.
		/// </summary>
		public int TotalItemPrice { get; set; }

		/// <summary>
		///   The currency value if the price of the product.
		/// </summary>
		public string CurrencyCode { get; set; }
	}
}

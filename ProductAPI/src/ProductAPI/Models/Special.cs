namespace ProductAPI.Models
{
	public class Special
	{	
		/// <summary>
		///   The amount needed to purchase.
		/// </summary>
		public int SpecialQuantity { get; set; }

		/// <summary>
		///   The special price offered.
		/// </summary>
		public int SpecialPrice { get; set; }

		/// <summary>
		///   The text to display to the user.
		/// </summary>
		public string SpecialText { get; set; }
	}
}
namespace ProductAPI.Models
{
	public class Restriction
	{	
		/// <summary>
		///   The maximum quantity allowed to be purchased.
		/// </summary>
		public int RestrictionQuantity { get; set; }

		/// <summary>
		///   The text to display to the user.
		/// </summary>
		public string RestrictionText { get; set; }
	}		
}
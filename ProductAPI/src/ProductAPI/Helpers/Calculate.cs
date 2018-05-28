using ProductAPI.Models;

namespace ProductAPI.Helpers
{
	public static class Calculate
	{
		public static int CalculateTotalItemPrice(Special special, int productPrice, int quantity)
		{
			var totalItemPrice = 0;

			//Is there a special and does it apply
			if (special != null && quantity >= special.SpecialQuantity)
			{
				//check how many items fall within the special price and how many within the standard price
				var standardPriceQuantity = quantity % special.SpecialQuantity;
				var specialPriceQuantity = quantity / special.SpecialQuantity;

				//calculate the special price
				var totalSpecialPrice = specialPriceQuantity * special.SpecialPrice;

				//calculate the standard price
				var totalStandardPrice = standardPriceQuantity * productPrice;

				//calculate the total price for all items
				totalItemPrice = totalSpecialPrice + totalStandardPrice;
			}
			//there is no special, but we still need to calculate the total item price.
			else
			{
				totalItemPrice = quantity * productPrice;
			}

			return totalItemPrice;
		}

		public static int CalculateDiscount (int totalItemPrice, int productPrice, int quantity)
		{
			return (productPrice * quantity) - totalItemPrice;
		}
	}
}
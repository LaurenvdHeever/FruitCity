using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductAPI.Helpers;
using ProductAPI.Models;

namespace ProductAPI.Tests
{
	[TestClass]
	public class CalculateTest
	{
		[TestMethod]
		public void Test_CalculatePriceForApple()
		{
			//Arrange
			int expected = 5;
			int productPrice = 2;
			int quantity = 3;

			var special = new Special
			{
				SpecialQuantity = 3,
				SpecialPrice = 5,
				SpecialText = "Woohoo! 3 for R5.00!"
			};

			//Act
			var result = Calculate.CalculateTotalItemPrice(special, productPrice, quantity);

			//Assert
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void Test_CalculatePriceForCoconut()
		{
			//Arrange
			int expected =8;
			int productPrice = 4;
			int quantity = 3;

			var special = new Special
			{
				SpecialQuantity = 3,
				SpecialPrice = 8,
				SpecialText = "Woohoo! Buy 2 Get 1 Free!"
			};

			//Act
			var result = Calculate.CalculateTotalItemPrice(special, productPrice, quantity);

			//Assert
			Assert.AreEqual(expected, result);
		}


		[TestMethod]
		public void Test_CalculateDiscounForApple()
		{
			//Arrange
			int expected = 1;
			int totalItemPrice = 5;
			int productPrice = 2;
			int quantity = 3;

			//Act
			var result = Calculate.CalculateDiscount(totalItemPrice, productPrice, quantity);

			//Assert
			Assert.AreEqual(expected, result);
		}


		[TestMethod]
		public void Test_CalculateDiscounForCoconut()
		{
			//Arrange
			int expected = 4;
			int totalItemPrice = 8;
			int productPrice = 4;
			int quantity = 3;

			//Act
			var result = Calculate.CalculateDiscount(totalItemPrice, productPrice, quantity);

			//Assert
			Assert.AreEqual(expected, result);
		}
	}
}

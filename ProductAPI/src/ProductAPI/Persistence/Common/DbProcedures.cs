namespace ProductAPI.Persistence.Common
{
	internal static class DbProcedures
	{
		//Products Data Access Commands
		internal static string CommandGetProducts = "SELECT * FROM tb_Product";
		internal static string CommandGetProduct = "SELECT * FROM tb_Product WHERE ProductId ={0}";
		internal static string CommandGetProductRestrictions = "SELECT * FROM tb_Restrictions WHERE ProductId = {0}";
		internal static string CommandGetProductSpecials = "SELECT * FROM tb_Specials WHERE ProductId = {0}";

		//Cart Data Access Commands
		internal static string CommandAddToCart =
			@"INSERT INTO tb_Cart (ProductId, Name, Quantity, ItemPrice, Discount, TotalItemPrice, CurrencyCode)
				SELECT tb_Product.ProductId, tb_Product.Name, 1, tb_Product.Price, 0, tb_Product.Price, tb_Product.CurrencyCode 
				FROM tb_Product
				WHERE tb_Product.ProductId = {0} and NOT EXISTS (SELECT ProductId FROM tb_Cart WHERE ProductId = {0}) LIMIT 1";
		internal static string CommandRemoveFromCart = "DELETE FROM tb_Cart WHERE ProductId = {0}";
		internal static string CommandUpdateCart = "UPDATE tb_Cart SET Quantity = {0}, Discount = {1}, TotalItemPrice = {2} WHERE ProductId = {3}";		
		internal static string CommandGetCartItems = "SELECT * FROM tb_Cart";
	}
}
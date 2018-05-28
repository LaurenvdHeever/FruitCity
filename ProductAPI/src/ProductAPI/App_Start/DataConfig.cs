using Dapper;
using System.Data.SQLite;
using System.IO;
using System.Web;

namespace ProductAPI
{
	internal static class DataConfig
	{
		private static SQLiteConnection _dbConnection;

		public static string InitialiseDatabase(string fileName)
		{
			var dbFile = HttpContext.Current.Server.MapPath(fileName);
			string connectionString = string.Format("DataSource={0};", dbFile);

			if (!File.Exists(dbFile))
			{
				SQLiteConnection.CreateFile(dbFile);
				_dbConnection = new SQLiteConnection(connectionString);				
				_dbConnection.OpenAsync();

				CreateProductTable();
				CreateSpecialsTable();
				CreateRestrictionsTable();
				CreateCartTable();

				_dbConnection.Close();				
			}

			return connectionString;
		}

		static void CreateProductTable()
		{
			// Create product table
			var productTable = @"CREATE TABLE IF NOT EXISTS[tb_Product](
						[ProductId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
						[Name] NVARCHAR(20) NOT NULL,
						[Description] NVARCHAR(100) NOT NULL,
						[Price] INTEGER NOT NULL,
						[CurrencyCode] NVARCHAR(10) NOT NULL)";

			_dbConnection.ExecuteAsync(productTable);

			// Insert product date
			var productData = @"INSERT INTO tb_Product
						(Name, Description, Price, CurrencyCode)
						VALUES
            ('Apple', 'Juicy Little Apple', '2', 'R'),
						('Coconut', 'Just A Coconut' ,'4', 'R'),
						('Banana', 'Ripe Little Banana', '3', 'R')";

			_dbConnection.ExecuteAsync(productData);
		}

		static void CreateSpecialsTable()
		{
			// Create specials table
			var specialsTable = @"CREATE TABLE IF NOT EXISTS[tb_Specials](
						[ProductId] INTEGER NOT NULL,
						[SpecialQuantity] INTEGER NOT NULL,
						[SpecialPrice] INTEGER  NOT NULL,					
						[SpecialText] NVARCHAR(100) NOT NULL,
						FOREIGN KEY (ProductId) REFERENCES tb_Product(ProductId))";

			_dbConnection.ExecuteAsync(specialsTable);

			// Insert specials data
			var specialsData = @"INSERT INTO tb_Specials
						(ProductId, SpecialQuantity, SpecialPrice, SpecialText)
						VALUES
            ('1', '3', '5', 'Woohoo! 3 for R5.00!'),
						('2', '3', '8', 'Woohoo! Buy 2 Get 1 Free!')";

			_dbConnection.ExecuteAsync(specialsData);
		}

		static void CreateRestrictionsTable()
		{
			// Create restrictions table
			var restrictionsTable = @"CREATE TABLE IF NOT EXISTS[tb_Restrictions](
						[ProductId] INTEGER NOT NULL,
						[RestrictionQuantity] INTEGER NOT NULL,						
						[RestrictionText] NVARCHAR(100) NOT NULL,
						FOREIGN KEY (ProductId) REFERENCES tb_Product(ProductId))";

			_dbConnection.ExecuteAsync(restrictionsTable);

			// Insert restrictions data
			var restrictionsData = @"INSERT INTO tb_Restrictions
						(ProductId, RestrictionQuantity, RestrictionText)
						VALUES            
						('3', '10', 'Do not go bananas! You cannot purchase more than 10')";

			_dbConnection.ExecuteAsync(restrictionsData);
		}

		static void CreateCartTable()
		{
			// Create product table
			var cartTable = @"CREATE TABLE IF NOT EXISTS[tb_Cart](
						[ProductId] INTEGER NOT NULL PRIMARY KEY,
						[Name] NVARCHAR(20) NOT NULL,
						[Quantity] INTEGER NOT NULL,				
						[ItemPrice] INTEGER NOT NULL,
						[Discount] INTEGER NOT NULL,
						[TotalItemPrice] INTEGER NOT NULL,
						[CurrencyCode] NVARCHAR(10) NOT NULL,
						FOREIGN KEY (ProductId) REFERENCES tb_Product(ProductId))";

			_dbConnection.ExecuteAsync(cartTable);			
		}
	}
}
using Dapper;
using ProductAPI.Models;
using ProductAPI.Persistence.Common;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ProductAPI.Persistence
{
	internal class ProductDataAccess : IProductDataAccess
	{
		private readonly IDbConnectionFactory _connectinFactory;
		private readonly string _connectionString;
		private readonly int _dbQueryTimeoutInSeconds;
		private readonly int _dbCallRetryCount;

		public ProductDataAccess(IDbConnectionFactory connectionFactory, string connectionString, int dbQueryTimeoutInSeconds, int dbCallRetryCount)
		{
			_connectinFactory = connectionFactory;
			_connectionString = connectionString;
			_dbQueryTimeoutInSeconds = dbQueryTimeoutInSeconds;
			_dbCallRetryCount = dbCallRetryCount;
		}

		public async Task<IEnumerable<Product>> GetProductsAsync()
		{
			using (var connection = await _connectinFactory.OpenAsync(_connectionString).ConfigureAwait(false))
			{
				var products = (await connection.QueryAsync<Product>(DbProcedures.CommandGetProducts, commandType: CommandType.Text, commandTimeout: _dbQueryTimeoutInSeconds).ConfigureAwait(false)).AsList();

				return products;
			}
		}

		public async Task<Product> GetProductAsync(int productId)
		{
			using (var connection = await _connectinFactory.OpenAsync(_connectionString).ConfigureAwait(false))
			{
				var product = await connection.QueryFirstOrDefaultAsync<Product>(string.Format(DbProcedures.CommandGetProduct, productId), commandType: CommandType.Text, commandTimeout: _dbQueryTimeoutInSeconds).ConfigureAwait(false);

				return product;
			}
		}

		public async Task<Restriction> GetProductRestrictionsAsync(int productId)
		{
			using (var connection = await _connectinFactory.OpenAsync(_connectionString).ConfigureAwait(false))
			{
				var restriction = await connection.QueryFirstOrDefaultAsync<Restriction>(string.Format(DbProcedures.CommandGetProductRestrictions, productId), commandType: CommandType.Text, commandTimeout: _dbQueryTimeoutInSeconds).ConfigureAwait(false);	

				return restriction;
			}
		}

		public async Task<Special> GetProductSpecialsAsync(int productId)
		{
			using (var connection = await _connectinFactory.OpenAsync(_connectionString).ConfigureAwait(false))
			{
				var special = await connection.QueryFirstOrDefaultAsync<Special>(string.Format(DbProcedures.CommandGetProductSpecials, productId), commandType: CommandType.Text, commandTimeout: _dbQueryTimeoutInSeconds).ConfigureAwait(false);

				return special;
			}
		}
	}
}
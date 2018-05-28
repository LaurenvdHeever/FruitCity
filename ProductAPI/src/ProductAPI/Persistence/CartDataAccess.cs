﻿using Dapper;
using ProductAPI.Helpers;
using ProductAPI.Models;
using ProductAPI.Persistence.Common;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ProductAPI.Persistence
{
	internal class CartDataAccess : ICartDataAccess
	{
		private readonly IDbConnectionFactory _connectinFactory;
		private readonly string _connectionString;
		private readonly int _dbQueryTimeoutInSeconds;
		private readonly int _dbCallRetryCount;

		public CartDataAccess(IDbConnectionFactory connectionFactory, string connectionString, int dbQueryTimeoutInSeconds, int dbCallRetryCount)
		{
			_connectinFactory = connectionFactory;
			_connectionString = connectionString;
			_dbQueryTimeoutInSeconds = dbQueryTimeoutInSeconds;
			_dbCallRetryCount = dbCallRetryCount;
		}

		public async Task AddCartItemAsync(int productId)
		{
			using (var connection = await _connectinFactory.OpenAsync(_connectionString).ConfigureAwait(false))
			{
				await connection.ExecuteAsync(string.Format(DbProcedures.CommandAddToCart, productId), commandType: CommandType.Text, commandTimeout: _dbQueryTimeoutInSeconds).ConfigureAwait(false);
			}
		}

		public async Task RemoveCartItemAsync(int productId)
		{
			using (var connection = await _connectinFactory.OpenAsync(_connectionString).ConfigureAwait(false))
			{
				await connection.ExecuteAsync(string.Format(DbProcedures.CommandRemoveFromCart, productId), commandType: CommandType.Text, commandTimeout: _dbQueryTimeoutInSeconds).ConfigureAwait(false);
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

		public async Task UpdateCartItemAsync(int productId, int quantity)
		{
			using (var connection = await _connectinFactory.OpenAsync(_connectionString).ConfigureAwait(false))
			{
				//get the standard price for the product
				var product = await connection.QueryFirstOrDefaultAsync<Product>(string.Format(DbProcedures.CommandGetProduct, productId), commandType: CommandType.Text, commandTimeout: _dbQueryTimeoutInSeconds).ConfigureAwait(false);
				
				//get any specials
				var special = await connection.QueryFirstOrDefaultAsync<Special>(string.Format(DbProcedures.CommandGetProductSpecials, productId), commandType: CommandType.Text, commandTimeout: _dbQueryTimeoutInSeconds).ConfigureAwait(false);

				var totalItemPrice = Calculate.CalculateTotalItemPrice(special, product.Price, quantity);

				////Is there a special and does it apply
				//if (special != null && quantity >= special.SpecialQuantity)
				//{
				//	//check how many items fall within the special price and how many within the standard price
				//	var standardPriceQuantity = quantity % special.SpecialQuantity;
				//	var specialPriceQuantity = quantity / special.SpecialQuantity;

				//	//calculate the special price
				//	var totalSpecialPrice = specialPriceQuantity * special.SpecialPrice;

				//	//calculate the standard price
				//	var totalStandardPrice = standardPriceQuantity * product.Price;					

				//	//calculate the total price for all items
				//	totalItemPrice = totalSpecialPrice + totalStandardPrice;
				//}
				////there is no special, but we still need to calculate the total item price.
				//else
				//{
				//	totalItemPrice = quantity * product.Price;
				//}

				var discount = Calculate.CalculateDiscount (totalItemPrice, product.Price, quantity);
				//var discount = (product.Price * quantity) - totalItemPrice;

				//update the cart
				await connection.ExecuteAsync(string.Format(DbProcedures.CommandUpdateCart, quantity, discount, totalItemPrice, productId), commandType: CommandType.Text, commandTimeout: _dbQueryTimeoutInSeconds).ConfigureAwait(false);
			}
		}

		public async Task<IEnumerable<CartItem>> GetCartAsync()
		{
			using (var connection = await _connectinFactory.OpenAsync(_connectionString).ConfigureAwait(false))
			{
				var cart = (await connection.QueryAsync<CartItem>(DbProcedures.CommandGetCartItems, commandType: CommandType.Text, commandTimeout: _dbQueryTimeoutInSeconds).ConfigureAwait(false)).AsList();

				return cart;
			}
		}
	}
}
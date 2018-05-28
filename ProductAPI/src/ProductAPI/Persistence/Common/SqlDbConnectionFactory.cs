using System.Data;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;

namespace ProductAPI.Persistence.Common
{
	internal class SqlDbConnectionFactory : IDbConnectionFactory
	{
		/// <summary>
		///   Creates and opens a database connection, given a connection string.
		/// </summary>
		/// <param name="connectionString"></param>	
		public async Task<IDbConnection> OpenAsync(string connectionString)
		{
			return await OpenAsync(connectionString, CancellationToken.None);
		}
	
		/// <param name="connectionString"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		public async Task<IDbConnection> OpenAsync(string connectionString, CancellationToken token)
		{
			var sqlConnection = new SQLiteConnection(connectionString);
			await sqlConnection.OpenAsync(token);
			return sqlConnection;
		}
	}
}
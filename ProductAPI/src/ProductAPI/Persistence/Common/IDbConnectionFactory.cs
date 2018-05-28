using System.Data;
using System.Threading.Tasks;

namespace ProductAPI.Persistence.Common
{
	/// <summary>
	///   Defines the interface for a SQL Server database connection factory.
	/// </summary>
	public interface IDbConnectionFactory
	{
		/// <summary>
		///   Creates and opens a database connection, given a connection string.
		/// </summary>
		/// <param name="connectionString">The connection string provifing details about the connection.</param>
		/// <returns>The opened connection.</returns>
		Task<IDbConnection> OpenAsync(string connectionString);
	}
}

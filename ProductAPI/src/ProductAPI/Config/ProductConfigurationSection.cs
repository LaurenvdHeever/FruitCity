using System.Configuration;

namespace ProductAPI.Config
{
	public class ProductConfigurationSection : ConfigurationSection
	{
		// <summary>
		/// The databse file name.
		/// </summary>
		[ConfigurationProperty("DatabaseFileName", IsRequired = true)]
		public string DatabaseFileName => (string)this["DatabaseFileName"];

		/// <summary>
		/// The duration of a DB query before it should time out and fail.
		/// </summary>
		[ConfigurationProperty("DbQueryTimeoutSeconds", IsRequired = false, DefaultValue = 30)]
		public int DbQueryTimeoutSeconds => (int)this["DbQueryTimeoutSeconds"];

		// <summary>
		/// The number of times a database call should be retried in the case of failure.
		/// </summary>
		[ConfigurationProperty("DbCallRetryCount", IsRequired = false, DefaultValue = 2)]
		public int DbCallRetryCount => (int)this["DbCallRetryCount"];
	}
}
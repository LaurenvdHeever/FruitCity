using ProductAPI.Config;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductAPI
{
	/// <summary>
	/// Web App Startup
	/// </summary>
	public class WebApiApplication : HttpApplication
	{
		/// <summary>
		/// Startup
		/// </summary>
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			UnityConfig.RegisterComponents();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			HanldeInitialisation();
		}

		/// <summary>
		/// Startup
		/// </summary>
		protected void Application_End()
		{		
		}

		/// <summary>
		/// This handles initialisation
		/// </summary>
		public override void Init()
		{		
		}

		/// <summary>
		/// Handles initialisation.
		/// </summary>
		private static void HanldeInitialisation()
		{
			var section = LoadConfigurationSection<ProductConfigurationSection>("product");

			var connectionString = DataConfig.InitialiseDatabase(section.DatabaseFileName);

			UnityConfig.RegisterProductDataAccessInstance(connectionString, section);
			UnityConfig.RegisterCartDataAccessInstance(connectionString, section);
		}

		private static T LoadConfigurationSection<T>(string sectionName) where T : ConfigurationSection
		{
			var config = WebConfigurationManager.OpenWebConfiguration("~");
			var section = config.GetSection(sectionName) as T;

			if (section == null)
			{
				throw new ConfigurationErrorsException($"Unable to load config section {sectionName}");
			}
			return section;
		}
	}
}

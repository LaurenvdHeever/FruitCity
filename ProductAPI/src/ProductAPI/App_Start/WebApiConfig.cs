using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Configuration;

namespace ProductAPI
{
	internal static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
					name: "ProductAPI",
					routeTemplate: "{controller}/{id}",
					defaults: new { id = RouteParameter.Optional }
			);

			ConfigureFormatters(config);
			ConfigureCors(config);
		}

		private static void ConfigureFormatters(HttpConfiguration config)
		{
			config.Formatters.Remove(config.Formatters.XmlFormatter);

			var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
			jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			// http://stackoverflow.com/questions/17855746/webapi-json-net-and-losing-decimal-precision
			jsonFormatter.SerializerSettings.Culture = new CultureInfo(String.Empty)
			{
				NumberFormat = new NumberFormatInfo
				{
					CurrencyDecimalDigits = 4
				}
			};

			//jsonFormatter.SerializerSettings.Converters.Add(new IsoTimeSpanConverter());
			jsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			jsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
		}

		private static void ConfigureCors(HttpConfiguration config)
		{
			var origins = ConfigurationManager.AppSettings["cors:Allow-Origin"];
			var headers = ConfigurationManager.AppSettings["cors:Allow-Headers"];
			var methods = ConfigurationManager.AppSettings["cors:Allow-Methods"];

			var cors = new EnableCorsAttribute(origins, headers, methods)
			{
				SupportsCredentials = true
			};
			config.EnableCors(cors);
		}
	}
}

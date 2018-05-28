using System.Web.Mvc;
using System.Web.Routing;

namespace ProductAPI
{
	public static class RouteConfig
	{
		public const string HelpRouteName = "Help Area";

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			// By default route the user to the Help area if accessing the base URI.
			routes.MapRoute(name: HelpRouteName, url: "{controller}/{action}", defaults: new { controller = "Help", action = "Index" })
				.DataTokens = new RouteValueDictionary(new { area = "HelpPage" });
		}
	}
}

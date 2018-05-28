using ProductAPI.Config;
using ProductAPI.Persistence;
using ProductAPI.Persistence.Common;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using Unity.Injection;

namespace ProductAPI
{
	internal static class UnityConfig
	{
		private static UnityContainer _container;

		public static void RegisterComponents()
		{
			_container = new UnityContainer();

			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(_container);
		}

		public static void RegisterProductDataAccessInstance(string connectionString, ProductConfigurationSection section)
		{			
			_container.RegisterType<IDbConnectionFactory, SqlDbConnectionFactory>();

			_container.RegisterType<IProductDataAccess, ProductDataAccess>(
				new InjectionConstructor(
				_container.Resolve<IDbConnectionFactory>(),
				new InjectionParameter<string>(connectionString),
				new InjectionParameter<int>(section.DbQueryTimeoutSeconds),
				new InjectionParameter<int>(section.DbCallRetryCount)));
		}

		public static void RegisterCartDataAccessInstance(string connectionString, ProductConfigurationSection section)
		{			
			_container.RegisterType<IDbConnectionFactory, SqlDbConnectionFactory>();

			_container.RegisterType<ICartDataAccess, CartDataAccess>(
				new InjectionConstructor(
				_container.Resolve<IDbConnectionFactory>(),
				new InjectionParameter<string>(connectionString),
				new InjectionParameter<int>(section.DbQueryTimeoutSeconds),
				new InjectionParameter<int>(section.DbCallRetryCount)));
		}
	}
}
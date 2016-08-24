using System;
using System.Web.Http;
using InfoDigest.DataLayer.Repositories;
using Ninject;
using WebApiContrib.IoC.Ninject;

namespace InfoDigest
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new NinjectResolver(CreateInfoDigestKernel());

            return config;
        }

        private static IKernel CreateInfoDigestKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<IInfoDigestApplicationUnit>().To<InfoDigestApplicationUnit>();
                return kernel;
            }
            catch (Exception)
            {
                kernel.Dispose();
                throw;
            }
        }

    }
}

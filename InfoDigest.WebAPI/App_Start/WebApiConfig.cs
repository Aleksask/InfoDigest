using System;
using System.Net.Http.Headers;
using System.Web.Http;
using InfoDigest.DataLayer.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ninject;
using WebApiContrib.IoC.Ninject;

namespace InfoDigest
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            SetMediaTypeFormatters(config);

            config.DependencyResolver = new NinjectResolver(CreateInfoDigestKernel());

            return config;
        }

        private static void SetMediaTypeFormatters(HttpConfiguration config)
        {
            config.Formatters.XmlFormatter.MediaTypeMappings.Clear();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json-patch+json"));
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
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

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(InfoDigest.Startup))]

namespace InfoDigest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWebApi(WebApiConfig.Register());
        }
    }
}
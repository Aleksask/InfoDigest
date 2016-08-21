using System;
using System.Web.Http;
using InfoDigest.App_Start;
using InfoDigest.DataLayer.Repositories;
using Microsoft.Owin;
using Ninject;
using Owin;
using WebApiContrib.IoC.Ninject;

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
using System.Web;

namespace InfoDigest.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
        }

        protected void Application_BeginRequest()
        {
            var ctxt= HttpContext.Current;
            var handler = ctxt.CurrentHandler;
        }
    }
}

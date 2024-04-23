using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Khatra
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        // Set the default language from configuration file in web.config
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var languageInSetting = ConfigurationManager.AppSettings["Language"].ToString();

            Thread.CurrentThread.CurrentCulture = new CultureInfo(languageInSetting);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageInSetting);
        }


    }
}

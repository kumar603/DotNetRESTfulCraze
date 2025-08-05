using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DotNetRESTfulCraze
{
/*****************************************************************************************************
Writer       : Kiran Kumar J
Description  : Get to know about Creating Restful API with create new model Product and loading data from
               Controllers and Configure the default route and register the route in App_Start event
Created Date : 05 - August - 2025
Created By   : Kiran Kumar
Changed Date : 05 - August - 2025
Changed By   : Kiran Kumar
JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-10
*****************************************************************************************************/
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

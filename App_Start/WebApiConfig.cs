using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DotNetRESTfulCraze
{
    /*****************************************************************************************************
Writer       : Kiran Kumar J
Description  : Get to know about Creating Restful API with create new model Product and loading data from
               Controllers and Configure the default route
Created Date : 05 - August - 2025
Created By   : Kiran Kumar
Changed Date : 05 - August - 2025
Changed By   : Kiran Kumar
JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-10
*****************************************************************************************************/
  
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotNetRESTfulCraze.Controllers
{
    /*****************************************************************************************************
    Writer       : Kiran Kumar J
    Description  : Get to know about Creating Restful API with  model Product and loading data from
                   Controllers and access the APIS with different Versions
    Created Date : 12 - August - 2025
    Created By   : Kiran Kumar
    Changed Date : 12 - August - 2025
    Changed By   : Kiran Kumar
    JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-16
    *****************************************************************************************************/
    [RoutePrefix("api/v1/products")]
    public class ProductsV1Controller : ApiController
    {
        [HttpGet, Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Television", "Camera" };
        }
    }

    [RoutePrefix("api/vII/products")]
    public class ProductsVIIController : ApiController
    {
        [HttpGet, Route("")]
        public IEnumerable<object> Get()
        {
            return new[]
            {
                new { Id = 1, Name = "Television", Price = 15000 },
                new { Id = 2, Name = "Camera", Price = 50000 }
            };
        }
    }
}

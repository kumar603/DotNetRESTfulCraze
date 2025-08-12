using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DotNetRESTfulCraze.Controllers
{
   /*****************************************************************************************************
   Writer       : Kiran Kumar J
   Description  : Get to know about Creating Restful API with  model Product and loading data from
                  Controllers and access the APIS with JWT Authentication
   Created Date : 12 - August - 2025
   Created By   : Kiran Kumar
   Changed Date : 12 - August - 2025
   Changed By   : Kiran Kumar
   JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-14
   *****************************************************************************************************/
    public class ProductsJWTController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/products/secure")]
        public IHttpActionResult GetSecureProducts()
        {
            return Ok(new { message = "Only authenticated users can access this." });
        }
    }
}
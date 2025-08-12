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
                  Controllers and Configure the exception filters
   Created Date : 12 - August - 2025
   Created By   : Kiran Kumar
   Changed Date : 12 - August - 2025
   Changed By   : Kiran Kumar
   JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-13
   *****************************************************************************************************/
    public class ProductsExceptionManagerController : ApiController
    {
        [HttpGet]
        [Route("api/ProductsExceptionManager/throw")]
        public IHttpActionResult ThrowError()
        {
            throw new Exception("Test exception in .NET Framework.");
        }

        //{
        //  "Message": "An unexpected error occurred.",
        //  "Details": "Test exception in .NET Framework."
        //}
    }
}

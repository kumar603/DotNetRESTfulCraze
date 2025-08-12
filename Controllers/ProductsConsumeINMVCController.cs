using DotNetRESTfulCraze.Models;
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
Description  : Get to know about Creating Restful API with create new model Product and loading data from
               Controllers and Consume the API from MVC Front UI application
Created Date : 05 - August - 2025
Created By   : Kiran Kumar
Changed Date : 05 - August - 2025
Changed By   : Kiran Kumar
JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-17
*****************************************************************************************************/
    public class ProductsConsumeINMVCController : ApiController
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Television", Price = 15000 },
            new Product { Id = 2, Name = "Camera", Price = 50000 }
        };

        // GET api/products
        [HttpGet]
        [Route("api/productsConsumeNVC")]
        public IEnumerable<Product> Get()
        {
            return products;
        }
    }
}

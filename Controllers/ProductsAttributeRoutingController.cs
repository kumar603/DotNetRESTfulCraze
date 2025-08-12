using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DotNetRESTfulCraze.Models;

namespace DotNetRESTfulCraze.Controllers
{
    /*****************************************************************************************************
    Writer       : Kiran Kumar J
    Description  : Get to know about Creating Restful API with  model Product and loading data from
                   Controllers and Configure the routes with attribute routing
    Created Date : 05 - August - 2025
    Created By   : Kiran Kumar
    Changed Date : 05 - August - 2025
    Changed By   : Kiran Kumar
    JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-11
    *****************************************************************************************************/
    /*
     * Common Routing Attributes:
     
        [Route("api/products")] – static route

        [Route("api/products/{id}")] – parameterized route

        [HttpGet], [HttpPost], [HttpPut], [HttpDelete] – HTTP verbs

        [HttpGet("byname/{name}")] – combining verb and path


        WebAPI_CRUD/
            ├── Controllers/
            │   └── ProductsAttributeRoutingController.cs
            ├── Models/
            │   └── Product.cs
            └── Program.cs
     */
    public class ProductsAttributeRoutingController : ApiController
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Television", Price = 15000 },
            new Product { Id = 2, Name = "Camera", Price = 50000 }
        };
        // GET: ProductsAttributeRouting
        // GET api/products
        [HttpGet]

        public IEnumerable<Product> GetAll()
            { return products; }

        // GET api/products/2
        public IHttpActionResult  GetById(int id)
        { var product = products.FirstOrDefault(p => p.Id == id); if (product == null) return NotFound(); return Ok(product); }

        // POST api/products/create
        [HttpPost]
        [Route("api/productsattributeroute/create")]
        public IHttpActionResult Create(Product product)
        { products.Add(product); return Ok(); }

        // PUT api/products/update/1
        [HttpPut]
        [Route("api/productsattributeroute/update/{id}")]
        public IHttpActionResult Update(int id, Product updated)
        { 
            var product = products.FirstOrDefault(p => p.Id == id); if (product == null) return NotFound();
            product.Name = updated.Name;   product.Price = updated.Price;
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE api/products/delete/1
        [HttpDelete]
        [Route("api/productsattributeroute/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);      if (product == null) return NotFound();
            products.Remove(product);
            
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
        // GET api/products/byname/TV
        [HttpGet]
        [Route("api/productsattributeroute/byname/{name}")]
        public IHttpActionResult GetByName(string name)
        {
            var product = products.FirstOrDefault(p => p.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}
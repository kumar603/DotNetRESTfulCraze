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
    Description  : Get to know about Creating Restful API with  model Product and loading data from
                   Controllers and Configure the routes with attribute routing and Validate Models
    Created Date : 12 - August - 2025
    Created By   : Kiran Kumar
    Changed Date : 12 - August - 2025
    Changed By   : Kiran Kumar
    JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-12
    *****************************************************************************************************/
    /*
     * Common Routing Attributes:
     
            [Required]

            [StringLength(max)]

            [Range(min, max)]

            [RegularExpression]
            
    
      ModelState.IsValid is field validate checker.



        WebAPI_CRUD/
            ├── Controllers/
            │   └── ProductsValidatedController.cs
            ├── Models/
            │   └── Product.cs
            └── Program.cs
     */
    public class ProductsValidatedController : ApiController
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Television", Price = 15000 },
            new Product { Id = 2, Name = "Camera", Price = 50000 }
        };
        // POST api/products/create
        [HttpPost]
        [Route("api/productsValidation/create")]
        public IHttpActionResult Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);

            return CreatedAtRoute(
                "GetProductById",
                new { id = product.Id },
                product
            );
        }
        // PUT api/products/update/1
        [HttpPut]
        [Route("api/productsValidation/update/{id}")]
        public IHttpActionResult Update(int id, [FromBody] Product updated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = updated.Name;
            product.Price = updated.Price;

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET api/products/1
        [HttpGet]
        [Route("api/productsValidation/{id}", Name = "GetProductById")]
        public IHttpActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}

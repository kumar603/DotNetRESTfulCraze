using DotNetRESTfulCraze.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DotNetRESTfulCraze.Controllers
{
    /*****************************************************************************************************
Writer       : Kiran Kumar J
Description  : Get to know about Creating Restful API with create new model Product and loading data from
                Controllers
Created Date : 05 - August - 2025
Created By   : Kiran Kumar
Changed Date : 05 - August - 2025
Changed By   : Kiran Kumar
JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-10
*****************************************************************************************************/
    /*
     * Products controller : Class derived from ApiController (or ControllerBase in .NET Core) to handle HTTP requests.
     *          
     * REST   : Architectural pattern using HTTP verbs to interact with resources.     
     * CRUD Operations : Create, Read, Update, Delete mapped to POST, GET, PUT, and DELETE methods respectively.
     * Features           :  Binding data with models and send as API response to client request
     * 
      GET >  api/products > IEnumerable<Product> > return products - All products - SELECT ALL PRODUCTS

      GET >   api/products/1 > IHttpActionResult Get(int id)   >  return Ok(product) - Get Specific Product by Its Id - SELECT WHERE CLAUSE

      POST > api/products > IHttpActionResult Post(Product product)   >  return Ok(product) - Save New Product - INSERT,CREATE
      
      PUT > api/products/1 > IHttpActionResult Put(int id, Product updated)   >  return Ok(product) - Change existing Product - UPDATE

      DELETE > api/products/1 > IHttpActionResult Delete(int id)   >  return Ok() - Delete existing Product - DELETE

     Project Structure Snapshot:
            WebAPI_CRUD/
        │
        ├── Controllers/
        │   └── ProductsController.cs
        │
        ├── Models/
        │   └── Product.cs

    Conclusion About LSP Principle : 
    Controller is the base for getting request from user and bind the data and send back to user as API or view
    In this example its a web api so it should return as Restful API Response
    Controller can get the Data from database or in memory and bind it to model
    Responses could be in the format of IHttpActionResult ,IEnumerable<Product>
     */
    public class ProductsController : ApiController
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Television", Price = 15000 },
            new Product { Id = 2, Name = "Camera", Price = 50000 }
        };

        // GET api/products
        public IEnumerable<Product> Get()
        {
            return products;
        }

        // GET api/products/1
        public IHttpActionResult Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST api/products
        public IHttpActionResult Post(Product product)
        {
            products.Add(product);
            return Ok(product);
        }

        // PUT api/products/1
        public IHttpActionResult Put(int id, Product updated)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = updated.Name;
            product.Price = updated.Price;
            return Ok(product);
        }

        // DELETE api/products/1
        public IHttpActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            products.Remove(product);
            return Ok();
        }
    }
}
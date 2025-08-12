using DotNetRESTfulCraze.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
    public class ProductsMVCAPIController : Controller
    {
        // Replace with your Web API port
        private readonly string baseUrl = "http://localhost:65030//api/productsConsumeNVC";

        // GET: Product
        public async Task<ActionResult> Index()
        {
            var products = new List<Product>();

            using (var client = new HttpClient())
            {
                // Send GET request to API
                HttpResponseMessage response = await client.GetAsync(baseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(jsonData);
                }
                else
                {
                    ViewBag.Error = "Error fetching products from API";
                }
            }

            return View(products);
        }
    }
}
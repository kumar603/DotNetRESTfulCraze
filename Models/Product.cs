using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetRESTfulCraze.Models
{
    /*****************************************************************************************************
Writer       : Kiran Kumar J
Description  : Get to know about Creating Restful API with create new model Product 
Created Date : 05 - August - 2025
Created By   : Kiran Kumar
Changed Date : 05 - August - 2025
Changed By   : Kiran Kumar
JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-10
*****************************************************************************************************/
    /*
     * Model :  Model to store the Data In Memory or database 
     *          C# class representing data structures (DTOs).
     *                                   
     * Features           :  Binding data with Views
                             

     Project Structure Snapshot:
            WebAPI_CRUD/
        │
        ├── Models/
        │   └── Product.cs

    Conclusion About LSP Principle : 
    Contrails the database fields and bind the data a collection object
    It can be used and manipulated through controller
    At getting data the model will be loading into Views page and it can bind with html helpers or get as api objects

     */
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
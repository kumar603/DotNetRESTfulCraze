using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetRESTfulCraze.Models
{
    /*****************************************************************************************************
    Writer       : Kiran Kumar J
    Description  : Get to know about Creating Restful API with create new model Product with validations
    Created Date : 12 - August - 2025
    Created By   : Kiran Kumar
    Changed Date : 12 - August - 2025
    Changed By   : Kiran Kumar
    JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-12
    *****************************************************************************************************/
    /*
     * Model :  Model to store the Data In Memory or database 
     *          C# class representing data structures (DTOs).
     *                                   
     * Features           :  Binding data with models and send the api request
                             

     Model validation uses data annotations on model properties 
     (like [Required], [StringLength], [Range]) to ensure valid 
     data is received. ASP.NET  automatically checks this and sets ModelState.IsValid.

     Project Structure Snapshot:
            WebAPI_CRUD/
        │
        ├── Models/
        │   └── ProductsValidated.cs


        [Required]

        [StringLength(max)]

        [Range(min, max)]

        [RegularExpression]

     */
    public class ProductsValidated
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name is Required.")]
        [StringLength(100,ErrorMessage = "Name can't exceed 100 characters.")]
        public string Name { get; set; }

        [Range(1, 1000000, ErrorMessage = "Price must be between 1 and 1,000,000.")]
        public double Price { get; set; }
    }
}
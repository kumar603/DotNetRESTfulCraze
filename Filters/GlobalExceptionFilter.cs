using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace DotNetRESTfulCraze.Filters
{
    /*****************************************************************************************************
     Writer       : Kiran Kumar J
     Description  : Get to know about Creating Restful API with  model Product and loading data from
                    Controllers and Configure Exception Filters
     Created Date : 12 - August - 2025
     Created By   : Kiran Kumar
     Changed Date : 12 - August - 2025
     Changed By   : Kiran Kumar
     JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-13
     *****************************************************************************************************/
    /*
     Exception Filters – implement IExceptionFilter
     ExceptionHandler – derive from ExceptionHandler and register it common to application
     */
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            // Log exception here if needed

            var response = new
            {
                Message = "An unexpected error occurred.",
                Details = context.Exception.Message
            };

            context.Response = context.Request.CreateResponse(
                HttpStatusCode.InternalServerError, response);
        }
    }
}
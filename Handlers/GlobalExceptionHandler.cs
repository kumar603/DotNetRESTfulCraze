using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http;

namespace DotNetRESTfulCraze.Handlers
{
    /*****************************************************************************************************
     Writer       : Kiran Kumar J
     Description  : Get to know about Creating Restful API with  model Product and loading data from
                    Controllers and Configure Exception Filters and handlers
     Created Date : 12 - August - 2025
     Created By   : Kiran Kumar
     Changed Date : 12 - August - 2025
     Changed By   : Kiran Kumar
     JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-13
     *****************************************************************************************************/
    /*
     Exception Filters – implement IExceptionFilter
     ExceptionHandler – derive from ExceptionHandler and register it common to application
                          ExceptionHandler for even broader scope (uncaught exceptions across all layers):
     */
    public class GlobalExceptionHandler :  ExceptionHandler
    {
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                Message = "An error occurred in the server.",
                Details = context.Exception.Message
            });

            context.Result = new ErrorMessageResult(context.Request, response);
            return Task.CompletedTask;
        }
    }
    // Helper class
    public class ErrorMessageResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly HttpResponseMessage _response;

        public ErrorMessageResult(HttpRequestMessage request, HttpResponseMessage response)
        {
            _request = request;
            _response = response;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_response);
        }
    }
}
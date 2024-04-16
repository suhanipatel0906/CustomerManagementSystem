using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http.Filters;

namespace CustomerManagement.API.GlobalException
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // Log the exception or perform any necessary actions
            // For example, you can log the exception to a file, database, or send an email notification

            // Return an appropriate HTTP response
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An error occurred, please try again later."),
                ReasonPhrase = "Internal Server Error"
            };
            actionExecutedContext.Response = response;
        }
    }
}
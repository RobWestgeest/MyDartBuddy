using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace MyDartBuddy.WebApi
{   
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
			if (actionExecutedContext.Exception.InnerException == null)
			{
				exceptionMessage = actionExecutedContext.Exception.Message;
			}
			else
			{
				exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
			}

			actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest)
			{
				Content = new StringContent(exceptionMessage),
				ReasonPhrase = "Bad Request"
			};			
		}
    }
    
}
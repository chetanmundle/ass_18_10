using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ValidatorsAndExceptionFilter.Filters
{
    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

            if (context.Exception is NotFoundException)
            {
                context.HttpContext.Response.StatusCode = 404;
            }else if (context.Exception is BadRequest)
            {
                context.HttpContext.Response.StatusCode = 400;
            }
            else
            {
                context.HttpContext.Response.StatusCode = 500;
            }

            context.Result = new JsonResult(new Dictionary<string, object>
            {
                { "status", context.HttpContext.Response.StatusCode},
                { "data" , context.Exception.Message },
                { "StackTrace", context.Exception.StackTrace }
            });
        }
    }

    // Custom NotFoundException
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }

    public class BadRequest : Exception
    {
        public BadRequest(string message) : base(message)
        {
            
        }
    }
}




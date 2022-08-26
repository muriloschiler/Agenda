using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Agenda.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Agenda.Application.Filters
{
    public class ApplicationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BadRequestException)
            {
                var exception = context.Exception as BadRequestException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(new
                {
                    Message = exception.Message,
                    Errors = exception.Errors.Select(vf=> new {
                        PropertyName = vf.PropertyName,
                        ErrorMessage = vf.ErrorMessage,
                        ErrorCode = 400   
                    })
                });
            }

            if (context.Exception is NotAuthorizedException)
            {
                var exception = context.Exception as NotAuthorizedException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new
                {
                    Message = exception.Message,
                    Errors = new Dictionary<string, string>()
                });
            }

            if (context.Exception is NotFoundException)
            {
                var exception = context.Exception as NotFoundException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new JsonResult(new
                {
                    Message = exception.Message,
                    Errors = new Dictionary<string, string>()
                });
            }
        }
    }
}
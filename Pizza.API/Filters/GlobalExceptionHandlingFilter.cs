using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pizza.Application.Exceptions;

namespace Pizza.API.Filters;

public class GlobalExceptionHandlingFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException)
        {
            context.Result = new ContentResult
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Content = context.Exception.Message
            };
        }
        else if (context.Exception is EntityNotFoundException)
        {
            context.Result = new ContentResult
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                Content = context.Exception.Message
            };
        }
    }
}

using System.Diagnostics;
using System.Net;
using Bazar.Core.Models;
using Exception = System.Exception;

namespace Bazar.Api.Middlewares;

public class GlobalExceptionMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger) =>
        _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ArgumentException argumentException)
        {
            
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error Occured");
            await HandlerException(context, e);
        }
    }

    private static Task HandlerException(HttpContext context, Exception e)
    {
        var errorResponse = new ErrorModel
        {
            Success = false,
            Message = e.Message,
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        return context.Response.WriteAsync(errorResponse.ToString());
    }
}
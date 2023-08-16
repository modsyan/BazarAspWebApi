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
        catch (Exception e)
        {
            _logger.LogError(e, "Error Occured");
            await HandlerException(context, e);
        }
    }

    private static Task HandlerException(HttpContext context, Exception e)
    {
        //TODO: make dynamic Internal code errors
        const int statusCode = (int)HttpStatusCode.InternalServerError;
        var errorResponse = new ErrorModel
        {
            StatusCode = statusCode,
            Message = e.Message,
            Details = e.InnerException?.ToString(),
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        return context.Response.WriteAsync(errorResponse.ToString());
    }
}
using System.Net;
using Bazar.Core.Constants;

namespace Bazar.Core.Exceptions;

public class AppException : Exception
{
    public HttpStatusCode HttpStatusCode { get; set; }
    public ApiResultStatusCode StatusCode { get; set; }
    public object? AdditionalData { get; set; }


    // public AppException(ApiResultStatusCode statusCode = ApiResultStatusCode.ServerError, string? message = null,
    //     HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError,
    //     Exception? exception = null, object? additionalData = null) : base(message, exception)
    // {
    //     StatusCode = statusCode;
    //     AdditionalData = additionalData;
    //     HttpStatusCode = httpStatusCode;
    // }

    public AppException(ApiResultStatusCode statusCode = ApiResultStatusCode.ServerError, string? message = null,
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError,
        Exception? exception = null, object? additionalData = null) : base(message, exception)
    {
        StatusCode = statusCode;
        AdditionalData = additionalData;
        HttpStatusCode = httpStatusCode;
    }


    public AppException()
        : this(ApiResultStatusCode.ServerError)
    {
    }

    public AppException(ApiResultStatusCode statusCode)
        : this(statusCode, null)
    {
    }

    public AppException(string message)
        : this(ApiResultStatusCode.ServerError, message)
    {
    }

    public AppException(ApiResultStatusCode statusCode, string message)
        : this(statusCode, message, HttpStatusCode.InternalServerError)
    {
    }
    
    public AppException(ApiResultStatusCode statusCode, HttpStatusCode httpStatusCode)
        : this(statusCode, null, httpStatusCode)
    {
    }


    public AppException(string message, object additionalData)
        : this(ApiResultStatusCode.ServerError, message, additionalData)
    {
    }

    public AppException(ApiResultStatusCode statusCode, object additionalData)
        : this(statusCode, null, additionalData)
    {
    }

    public AppException(ApiResultStatusCode statusCode, string message, object additionalData)
        : this(statusCode, message, HttpStatusCode.InternalServerError, additionalData)
    {
    }

    public AppException(ApiResultStatusCode statusCode, string message, HttpStatusCode httpStatusCode)
        : this(statusCode, message, httpStatusCode, null)
    {
    }

    public AppException(ApiResultStatusCode statusCode, string message, HttpStatusCode httpStatusCode,
        Exception exception) : this(statusCode, message, httpStatusCode, exception, null)
    {
    }

    public AppException(ApiResultStatusCode statusCode, string message, HttpStatusCode httpStatusCode,
        object additionalData)
        : this(statusCode, message, httpStatusCode, null, additionalData)
    {
    }

    public AppException(ApiResultStatusCode statusCode, string message, Exception exception, object additionalData)
        : this(statusCode, message, HttpStatusCode.InternalServerError, exception, additionalData)
    {
    }

    public AppException(ApiResultStatusCode statusCode, string message, Exception exception)
        : this(statusCode, message, HttpStatusCode.InternalServerError, exception, null)
    {
    }

    public AppException(string message, Exception exception)
        : this(ApiResultStatusCode.ServerError, message, exception)
    {
    }

    public AppException(string message, Exception exception, object additionalData)
        : this(ApiResultStatusCode.ServerError, message, exception, additionalData)
    {
    }
}
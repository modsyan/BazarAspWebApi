using System.Net;
using Bazar.Core.Constants;

namespace Bazar.Core.Exceptions;

public class UnAuthorizedException: AppException
{
    public UnAuthorizedException()
        : base(ApiResultStatusCode.UnAuthorized, HttpStatusCode.Unauthorized)
    {
    }

    public UnAuthorizedException(string message)
        : base(ApiResultStatusCode.UnAuthorized, message, HttpStatusCode.Unauthorized)
    {
    }

    public UnAuthorizedException(object additionalData)
        : base(ApiResultStatusCode.UnAuthorized, null, HttpStatusCode.Unauthorized, additionalData)
    {
    }

    public UnAuthorizedException(string message, Exception exception)
        : base(ApiResultStatusCode.UnAuthorized, message, exception, HttpStatusCode.Unauthorized)
    {
    }

    public UnAuthorizedException(string message, Exception exception, object additionalData)
        : base(ApiResultStatusCode.UnAuthorized, message, HttpStatusCode.Unauthorized, exception, additionalData)
    {
    }
}
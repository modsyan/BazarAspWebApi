using Microsoft.AspNetCore.Mvc.Filters;

namespace Bazar.Api.Identity;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RequireClaimAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        throw new NotImplementedException();
    }
}
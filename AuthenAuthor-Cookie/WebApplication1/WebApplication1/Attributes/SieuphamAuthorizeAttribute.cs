using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace WebApplication1.Attributes;

public class SieuphamAuthorizeAttribute : TypeFilterAttribute
{
    public string RoleName { get; set; }
    public string ActionValue { get; set; }
    public SieuphamAuthorizeAttribute(string roleName, string actionValue) : base(typeof(SieuphamAuthorizeFilter))
    {
        RoleName = roleName;
        ActionValue = actionValue;
        Arguments = new object[] { RoleName, ActionValue };
    }
}

public class SieuphamAuthorizeFilter : IAuthorizationFilter
{
    public string RoleName { get; set; }
    public string ActionValue { get; set; }

    public SieuphamAuthorizeFilter(string roleName, string actionValue)
    { 
        RoleName = roleName;
        ActionValue = actionValue;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var hasRole = CanAccessToAction(context.HttpContext);
        if (!hasRole)
            context.Result = new ForbidResult();
    }

    private bool CanAccessToAction(HttpContext httpContext)
    {
        var roles = httpContext.User.FindFirstValue(ClaimTypes.Role).Split(new char[] {','}).ToList();

        foreach (var role in roles)
        {
            if (role.Trim().Equals(RoleName))
                return true;
        }
        return false;
    }
}

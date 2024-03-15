using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace WebApplication1.Events;

public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
{

    public CustomCookieAuthenticationEvents()
    {

    }

    public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
    {
        //var user = context.Principal?.FindFirstValue(ClaimTypes.Name) ?? string.Empty;

        //if (string.IsNullOrEmpty(user))
        //    context.RejectPrincipal();
    }
}
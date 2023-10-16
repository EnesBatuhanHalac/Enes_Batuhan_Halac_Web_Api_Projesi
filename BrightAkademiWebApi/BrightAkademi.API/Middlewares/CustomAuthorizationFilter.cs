using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BrightAkademi.API.Middlewares
{
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // You can perform your custom authorization logic here.
            // If the user is authorized, do nothing. Otherwise, change the status code.
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new OkResult(); // Change this to any other IActionResult if needed
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using BrightAkademi.Shared.ResponseDTOs;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BrightAkademi.API.Middlewares
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var statusCode = context.HttpContext.Response.StatusCode;
            var response = new CustomResponse { StatusCode= statusCode };
            var strResponse = JsonSerializer.Serialize(response);

            if (statusCode == 403)
            {
                context.Result = new ForbidResult();
            }
            if (statusCode == 401)
            {
                context.Result =new UnauthorizedResult();

            }



        }
    }
}

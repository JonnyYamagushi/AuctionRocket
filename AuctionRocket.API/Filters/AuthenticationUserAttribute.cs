using AuctionRocket.API.DataAcess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.AccessControl;

namespace AuctionRocket.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);

            var email = FromBase64String(token);

            var exist = new UsersDataAcess().ExistUser(email).Result;

            if (exist == false)
            {
                context.Result = new UnauthorizedObjectResult("Token not valid");
            }
        }
        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }        
    }

    private string TokenOnRequest(HttpContext context)
    {
        var Auth = context.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(Auth))
        {
            throw new Exception("Token is missing.");
        }

        return Auth["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}

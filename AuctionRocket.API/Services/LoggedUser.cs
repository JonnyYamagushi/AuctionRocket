using AuctionRocket.API.DataAcess;
using AuctionRocket.API.Domain.Entities;

namespace AuctionRocket.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _contextAccessor;

    public LoggedUser(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public User? User()
    {
        var token = TokenOnRequest();
        var email = FromBase64String(token);

        return new UsersDataAcess().GetUser(email).Result;
    }

    private string TokenOnRequest()
    {
        var Auth = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return Auth["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}

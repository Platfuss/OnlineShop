using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DataAccess.Services;
public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetEmail() =>
        _httpContextAccessor.HttpContext != null
           ? _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email)
           : string.Empty;
}

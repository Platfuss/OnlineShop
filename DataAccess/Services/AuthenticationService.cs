using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Models.Dto.Requests;
using DataAccess.Models.Dto.Responses;
using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace DataAccess.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly DataContext _db;
    private readonly IUserService _userService;
    private readonly IConfiguration _config;
    private readonly ITokenService _tokenService;

    //TODO: change for real values
    private readonly DateTime _jwtShouldExpire = DateTime.UtcNow.AddSeconds(10);
    private readonly DateTime _refreshTokenShouldExpire = DateTime.UtcNow.AddSeconds(30);

    private readonly string _jwtConfigName;
    private readonly string _refreshTokenConfigName;

    public AuthenticationService(DataContext db, IUserService userService, IConfiguration config, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _db = db;
        _userService = userService;
        _config = config;
        _tokenService = tokenService;

        _jwtConfigName = _config.GetSection("Jwt:JwtName").Value;
        _refreshTokenConfigName = _config.GetSection("Jwt:RefreshTokenName").Value;
    }

    public async Task<TokenResponse> RegisterAsync(UserRequest userDto)
    {
        var userAlreadyExists = (await _db.Users.Where(u => u.Email == userDto.Email).FirstOrDefaultAsync())
            != null;
        if (userAlreadyExists)
            return null;

        var customer = _db.Customers.Add(new Customer());
        await _db.SaveChangesAsync();

        CreatePasswordHash(userDto.Password,
            out byte[] passwordHash,
            out byte[] passwordSalt);

        var userModel = new User()
        {
            Email = userDto.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Customer = customer.Entity
        };

        _db.Add(userModel);
        await _db.SaveChangesAsync();

        return await LoginAsync(userDto);
    }

    public async Task<TokenResponse> LoginAsync(UserRequest userDto)
    {
        var user = await _db.Users.Where(u => u.Email == userDto.Email).FirstOrDefaultAsync();
        if (user == null)
            return null;

        if (!CheckPassword(userDto.Password, user.PasswordHash, user.PasswordSalt))
            return null;

        var jwt = _tokenService.CreateJwt(user, _jwtShouldExpire);
        var refreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpirationTime = _refreshTokenShouldExpire;

        var cookies = _httpContextAccessor.HttpContext.Response.Cookies;
        //TODO: samesite, secure >>>
        cookies.Append(_jwtConfigName,
                       jwt,
                       new CookieOptions()
                       {
                           HttpOnly = true,
                           SameSite = SameSiteMode.None,
                           Secure = true,
                           Expires = _refreshTokenShouldExpire
                       });

        cookies.Append(_refreshTokenConfigName,
                       refreshToken,
                       new CookieOptions()
                       {
                           Path = "api/authentication/refresh-access-token",
                           HttpOnly = true,
                           SameSite = SameSiteMode.None,
                           Secure = true,
                           Expires = _refreshTokenShouldExpire
                       }); ;

        await _db.SaveChangesAsync();
        return new TokenResponse { JwtExpirationDate = _jwtShouldExpire, RefreshTokenExpirationDate = _refreshTokenShouldExpire };
    }

    public async Task<TokenResponse> RefreshJwtAsync()
    {
        var user = await _userService.GetUserAsync();

        if (user.RefreshTokenExpirationTime < DateTime.UtcNow)
            return null;

        var refreshToken = _httpContextAccessor.HttpContext.Request.Cookies[_refreshTokenConfigName];
        if (refreshToken != user.RefreshToken)
            return null;

        var token = _tokenService.CreateJwt(user, _jwtShouldExpire);
        //TODO: samesite, secure >>>
        _httpContextAccessor.HttpContext.Response.Cookies
           .Append(_jwtConfigName,
                    token,
                    new CookieOptions()
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.None,
                        Secure = true,
                        Expires = _refreshTokenShouldExpire
                    });

        return new TokenResponse { JwtExpirationDate = _jwtShouldExpire, RefreshTokenExpirationDate = user.RefreshTokenExpirationTime };
    }

    public async Task<bool> RevokeAccess()
    {
        var tokenNames = new List<string>() { _jwtConfigName, _refreshTokenConfigName };

        var oldCookies = _httpContextAccessor.HttpContext.Request.Cookies;
        var newCookies = _httpContextAccessor.HttpContext.Response.Cookies;

        foreach (var name in tokenNames)
        {
            if (oldCookies[name] != null)
            {
                newCookies.Append(name, "", new CookieOptions { Expires = DateTime.UtcNow.AddDays(-1) });
            }
        }

        var user = await _userService.GetUserAsync();
        user.RefreshToken = string.Empty;
        user.RefreshTokenExpirationTime = DateTime.UtcNow.AddDays(-1);

        await _db.SaveChangesAsync();

        return true;
    }

    private static void CreatePasswordHash(string password,
        out byte[] passwordHash,
        out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    private static bool CheckPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }
}

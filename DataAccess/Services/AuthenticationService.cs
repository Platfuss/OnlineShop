using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Models.Dto.Requests;
using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DataAccess.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IConfiguration _config;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly DataContext _db;
    private readonly IUserService _userService;
    private readonly DateTime _jwtShouldExpire = DateTime.Now.AddMinutes(5);

    public AuthenticationService(DataContext db, IUserService userService, IConfiguration config, IHttpContextAccessor httpContextAccessor)
    {
        _config = config;
        _httpContextAccessor = httpContextAccessor;
        _db = db;
        _userService = userService;
    }

    public async Task<bool> RegisterAsync(UserRequest userDto)
    {
        var userAlreadyExists = (await _db.Users.Where(u => u.Email == userDto.Email).FirstOrDefaultAsync())
            != null;
        if (userAlreadyExists)
            return false;

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

    public async Task<bool> LoginAsync(UserRequest userDto)
    {
        var user = await _db.Users.Where(u => u.Email == userDto.Email).FirstOrDefaultAsync();
        if (user == null)
            return false;

        if (!CheckPassword(userDto.Password, user.PasswordHash, user.PasswordSalt))
            return false;

        var token = CreateToken(user, _jwtShouldExpire);
        var refreshToken = GenerateRefreshToken();
        user.RefreshToken = refreshToken;
        var refreshTokenExpireTime = DateTime.UtcNow.AddDays(1);
        user.RefreshTokenExpireTime = refreshTokenExpireTime;


        var cookies = _httpContextAccessor.HttpContext.Response.Cookies;
        //TODO: samesite, secure >>>
        cookies.Append("jwt",
                       token,
                       new CookieOptions()
                       {
                           HttpOnly = true,
                           SameSite = SameSiteMode.None,
                           Secure = true,
                           Expires = _jwtShouldExpire
                       });

        cookies.Append("refresh-token",
                       refreshToken,
                       new CookieOptions()
                       {
                           Path = "api/authentication/refresh-access-token",
                           HttpOnly = true,
                           SameSite = SameSiteMode.None,
                           Secure = true,
                           Expires = refreshTokenExpireTime
                       });

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RefreshAccessToken()
    {
        var user = await _userService.GetUserAsync();
        if (user.RefreshTokenExpireTime < DateTime.UtcNow)
            return false;

        var refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["refresh-token"];
        if (refreshToken != user.RefreshToken)
            return false;

        var token = CreateToken(user, _jwtShouldExpire);
        var cookies = _httpContextAccessor.HttpContext.Response.Cookies;
        //TODO: samesite, secure >>>
        cookies.Append("jwt",
                       token,
                       new CookieOptions()
                       {
                           HttpOnly = true,
                           SameSite = SameSiteMode.None,
                           Secure = true,
                           Expires = _jwtShouldExpire
                       });

        return true;
    }
    public async Task<bool> RevokeAccess()
    {
        var tokenNames = new List<string>() { "jwt", "refresh-token" };
        var oldCookies = _httpContextAccessor.HttpContext.Request.Cookies;
        var newCookies = _httpContextAccessor.HttpContext.Response.Cookies;

        foreach (var name in tokenNames)
        {
            if (oldCookies[name] != null)
            {
                newCookies.Append(name, "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
            }
        }

        var user = await _userService.GetUserAsync();
        user.RefreshToken = string.Empty;
        user.RefreshTokenExpireTime = DateTime.Now.AddDays(-1);

        await _db.SaveChangesAsync();

        return true;
    }

    private string CreateToken(User userModel, DateTime whenExpires, bool isAdmin = false)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, userModel.Email)
        };

        if (isAdmin)
        {
            var adminClaim = new Claim(ClaimTypes.Role, "Admin");
            claims.Add(adminClaim);
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Token").Value));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: whenExpires,
            signingCredentials: cred);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
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

    private static string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }
}

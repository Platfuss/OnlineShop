using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Models.Dto;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DataAccess.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IConfiguration _config;
    private readonly DataContext _db;

    public AuthorizationService(IConfiguration config, DataContext db)
    {
        _config = config;
        _db = db;
    }

    public async Task<string> RegisterAsync(UserDto userDto)
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

        var userModel = new User() { Email = userDto.Email, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Customer = customer.Entity };
        _db.Add(userModel);
        await _db.SaveChangesAsync();

        return await LoginAsync(userDto);
    }

    public async Task<string> LoginAsync(UserDto userDto)
    {
        var user = await _db.Users.Where(u => u.Email == userDto.Email).FirstOrDefaultAsync();
        if (user == null)
            return null;

        if (!CheckPassword(userDto.Password, user.PasswordHash, user.PasswordSalt))
            return null;

        return CreateToken(user);
    }

    private string CreateToken(User userModel, bool isAdmin = false)
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
            expires: DateTime.Now.AddDays(1),
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
}

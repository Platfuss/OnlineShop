using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DataAccess.Services;
public class UserService : IUserService
{
    private readonly DataContext _db;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(DataContext db, IHttpContextAccessor httpContextAccessor)
    {
        _db = db;
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetEmail() =>
        _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);

    public async Task<Customer> GetCustomerAsync()
    {
        var email = GetEmail();
        var user = await _db.Users.Include(u => u.Customer).Where(u => u.Email == email).FirstAsync();
        return user.Customer;
    }

    public async Task<int> GetCustomerIdAsync()
    {
        var customer = await GetCustomerAsync();
        return customer.Id;
    }
}

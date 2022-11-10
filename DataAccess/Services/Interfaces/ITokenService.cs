using DataAccess.Models.Database;

namespace DataAccess.Services.Interfaces;
public interface ITokenService
{
    string CreateJwt(User userModel, DateTime whenExpires, bool isAdmin = false);
    string GenerateRefreshToken();
}
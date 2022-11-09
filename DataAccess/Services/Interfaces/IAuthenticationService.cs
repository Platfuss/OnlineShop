using DataAccess.Models.Dto.Requests;

namespace DataAccess.Services.Interfaces;

public interface IAuthenticationService
{
    Task<bool> LoginAsync(UserRequest userDto);
    Task<bool> RefreshAccessToken();
    Task<bool> RegisterAsync(UserRequest userDto);
    Task<bool> RevokeAccess();
}
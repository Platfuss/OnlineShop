using DataAccess.Models.Dto.Requests;
using DataAccess.Models.Dto.Responses;

namespace DataAccess.Services.Interfaces;

public interface IAuthenticationService
{
    Task<TokenResponse> LoginAsync(UserRequest userDto);
    Task<TokenResponse> RefreshJwtAsync();
    Task<TokenResponse> RegisterAsync(UserRequest userDto);
    Task<bool> RevokeAccess();
}
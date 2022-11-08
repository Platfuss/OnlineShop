using DataAccess.Models.Dto.Requests;

namespace DataAccess.Services.Interfaces;

public interface IAuthorizationService
{
    Task<string> LoginAsync(UserRequest userDto);
    Task<string> RegisterAsync(UserRequest userDto);
}
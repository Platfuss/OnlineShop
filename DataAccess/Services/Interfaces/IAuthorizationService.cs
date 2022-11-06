using DataAccess.Models.Dto;

namespace DataAccess.Services.Interfaces;

public interface IAuthorizationService
{
    Task<string> LoginAsync(UserDto userDto);
    Task<string> RegisterAsync(UserDto userDto);
}
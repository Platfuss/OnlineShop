using DataAccess.Models.Dto;

namespace DataAccess.Services.Interfaces;

public interface IAuthorizationService
{
    Task<string> Login(UserDto userDto);
    Task<string> Register(UserDto userDto);
}
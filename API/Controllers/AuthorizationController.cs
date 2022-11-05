using DataAccess.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthorizationService _authorization;

    public AuthorizationController(IAuthorizationService authorization)
    {
        _authorization = authorization;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<string>> Register(UserDto userDto)
    {
        return Ok(await _authorization.Register(userDto));
    }

    [HttpPost("Login")]
    public async Task<ActionResult<string>> Login(UserDto userDto)
    {
        return Ok(await _authorization.Login(userDto));
    }
}

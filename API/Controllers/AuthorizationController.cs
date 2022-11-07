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

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register(UserDto userDto)
    {
        return Ok(await _authorization.RegisterAsync(userDto));
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(UserDto userDto)
    {
        return Ok(await _authorization.LoginAsync(userDto));
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IAuthenticationService = DataAccess.Services.Interfaces.IAuthenticationService;

namespace API.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authentication;

    public AuthenticationController(IAuthenticationService authentication)
    {
        _authentication = authentication;
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register(UserRequest userDto)
    {
        return Ok(await _authentication.RegisterAsync(userDto));
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(UserRequest userDto)
    {
        return Ok(await _authentication.LoginAsync(userDto));
    }

    [Authorize]
    [HttpPost("refresh-access-token")]
    public async Task<ActionResult<bool>> RefreshAccessToken()
    {
        return Ok(await _authentication.RefreshAccessToken());
    }

    [Authorize]
    [HttpPost("revoke-access")]
    public async Task<ActionResult<bool>> RevokeAccess()
    {
        return Ok(await _authentication.RevokeAccess());
    }
}

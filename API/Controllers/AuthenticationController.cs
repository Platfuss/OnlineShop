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
    public async Task<ActionResult<TokenResponse>> Register(UserRequest userDto)
    {
        return Ok(await _authentication.RegisterAsync(userDto));
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenResponse>> Login(UserRequest userDto)
    {
        return Ok(await _authentication.LoginAsync(userDto));
    }

    [HttpPost("refresh-access-token")]
    [Authorize]
    public async Task<ActionResult<TokenResponse>> RefreshAccessToken()
    {
        return Ok(await _authentication.RefreshJwtAsync());
    }

    [HttpDelete("revoke-access")]
    [Authorize]
    public async Task<ActionResult<bool>> RevokeAccess()
    {
        return Ok(await _authentication.RevokeAccess());
    }
}

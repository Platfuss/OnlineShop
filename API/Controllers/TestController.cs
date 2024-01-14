using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("ping")]
    public string Ping()
    {
        return $"It's {DateTime.Now}";
    }
}

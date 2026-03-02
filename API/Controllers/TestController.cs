using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("teste")]
public class TestController : ControllerBase
{
    [HttpGet("publico")]
    public IActionResult Public()
    {
        return Ok("Endpoint público");
    }

    [Authorize]
    [HttpGet("privado")]
    public IActionResult Private()
    {
        return Ok("Você está autenticado ");
    }
}
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers;

[ApiController]
[Route("config")]
public class ConfigController : ControllerBase
{

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello");
    }
}
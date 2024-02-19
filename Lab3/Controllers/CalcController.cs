using Lab3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers;

[ApiController]
[Route("calc")]
public class CalcController : ControllerBase
{
    private readonly ICalcService _calcService;

    public CalcController(ICalcService calcService)
    {
        _calcService = calcService;
    }

    [HttpGet("add")]
    public IActionResult Add([FromQuery] int a, [FromQuery] int b)
    {
        return Ok(_calcService.Add(a, b));
    }
    
    [HttpGet("subtract")]
    public IActionResult Subtract([FromQuery] int a, [FromQuery] int b)
    {
        return Ok(_calcService.Subtract(a, b));
    }
    
    [HttpGet("multiply")]
    public IActionResult Multiply([FromQuery] int a, [FromQuery] int b)
    {
        return Ok(_calcService.Multiply(a, b));
    }
    
    [HttpGet("divide")]
    public IActionResult Divice([FromQuery] int a, [FromQuery] int b)
    {
        return Ok(_calcService.Divide(a, b));
    }
}
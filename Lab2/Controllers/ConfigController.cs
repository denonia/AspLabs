using Lab2.Models;
using Lab2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers;

[ApiController]
[Route("config")]
public class ConfigController : ControllerBase
{
    private readonly CompanyService _companyService;
    private readonly IConfiguration _configuration;

    public ConfigController(CompanyService companyService, IConfiguration configuration)
    {
        _companyService = companyService;
        _configuration = configuration;
    }

    [HttpGet("companies")]
    public IActionResult GetCompanies()
    {
        return Ok(_companyService.GetCompanyWithMostEmployees());
    }
    
    [HttpGet("aboutme")]
    public IActionResult GetAboutMe()
    {
        return Ok(_configuration.GetSection("AboutMe").Get<AboutMe>());
    }
}
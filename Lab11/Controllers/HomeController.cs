using System.Diagnostics;
using Lab11.Filters;
using Microsoft.AspNetCore.Mvc;
using Lab11.Models;

namespace Lab11.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [ActionLogFilter]
    public IActionResult Index()
    {
        return View();
    }

    [ActionLogFilter]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
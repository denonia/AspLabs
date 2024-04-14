using Lab12.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lab12.Controllers;

public class CompaniesController : Controller
{
    private readonly AppDbContext _appDbContext;

    public CompaniesController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public IActionResult Index()
    {
        return View(_appDbContext.Companies);
    }
}
using Lab6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers;

public class OrderController : Controller
{
    [HttpPost]
    public IActionResult Index(string phone, string address, int amount)
    {
        return View(new OrderViewModel(new User(address, phone), amount));
    }

    [HttpPost]
    public IActionResult Confirm(Product[] products)
    {
        return View(new ConfirmOrderViewModel(products));
    }
}
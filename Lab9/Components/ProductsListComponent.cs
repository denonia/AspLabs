using Lab9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab9.Components;

public class ProductsListComponent : ViewComponent
{
    public IViewComponentResult Invoke(IEnumerable<Product> products)
    {
        return View(products);
    }
}
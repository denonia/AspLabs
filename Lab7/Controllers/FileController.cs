using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Controllers;

public class FileController : Controller
{
    public IActionResult DownloadFile()
    {
        return View();
    }

    public IActionResult ProcessFile(string firstName, string lastName, string fileName)
    {
        var bytes = Encoding.UTF8.GetBytes($"{firstName} {lastName}");
        return File(bytes, "text/plain", fileName);
    }
}
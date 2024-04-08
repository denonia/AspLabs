using Lab10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Controllers;

public class RegistrationController : Controller
{
    public IActionResult Index()
    {
        return View(new RegistrationModel());
    }

    public IActionResult Success(Registration registration)
    {
        return View(registration);
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult CheckDate([Bind(Prefix = "Registration.Date")] DateOnly date)
    {
        if (date < DateOnly.FromDateTime(DateTime.Now))
        {
            return Json("На жаль, ми не проводимо консультації у минулому часі");
        }
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            return Json("Ми не проводимо консультації по вихідним");
        }
        
        return Json(true);
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult CheckMonday([Bind(Prefix = "Registration.Course")] string course,
        [Bind(Prefix = "Registration.Date")] DateOnly date)
    {
        return Json(!(course == "Основи" && date.DayOfWeek == DayOfWeek.Monday));
    }
}
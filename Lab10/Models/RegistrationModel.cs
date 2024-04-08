using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab10.Models;

public class RegistrationModel
{
    public SelectList Courses = new(new List<string>
    {
        "JavaScript",
        "C#",
        "Java",
        "Python",
        "Основи",
    });
    
    [BindProperty]
    public Registration Registration { get; set; }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Models;

public class Registration
{
    [Required(ErrorMessage = "Ім'я та прізвище є обов'язковими")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Електронна адреса є обов'язковою")]
    [EmailAddress(ErrorMessage = "Невірний формат електроної адреси")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Дата консультації є обов'язковою")]
    [DataType(DataType.Date, ErrorMessage = "Неправильний формат дати")]
    [Remote(controller: "Registration", action: "CheckDate")]
    public DateOnly Date { get; set; }

    [Required(ErrorMessage = "Курс є обов'язковим")]
    [Remote(controller: "Registration", action: "CheckMonday", AdditionalFields = nameof(Date),
        ErrorMessage = "Ми не проводимо консультації щодо продукту «Основи» по понеділкам")]
    public string Course { get; set; }
}
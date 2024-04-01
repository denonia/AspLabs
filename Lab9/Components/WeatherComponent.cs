using Lab9.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab9.Components;

public class WeatherComponent : ViewComponent
{
    private readonly WeatherService _weatherService;

    public WeatherComponent(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync(double lat, double lon)
    {
        return View(await _weatherService.GetWeatherAsync(lat, lon));
    }
}
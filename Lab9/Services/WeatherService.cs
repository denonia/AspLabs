using System.Text.Json;
using Lab9.Models;

namespace Lab9.Services;

public class WeatherService
{
    private const string BaseUrl = "https://api.open-meteo.com/v1/forecast";
    private const string ParametersTemplate = "?latitude={0}&longitude={1}&current=temperature_2m,wind_speed_10m";

    public async Task<WeatherResult> GetWeatherAsync(double lat, double lon)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(BaseUrl);
            var result = await client.GetAsync(string.Format(ParametersTemplate, lat, lon));
            result.EnsureSuccessStatusCode();
            var resultContentString = await result.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<WeatherResult>(resultContentString);
        }
    }
}
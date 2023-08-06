using System.Net.Http.Json;
using Template.Shared;
using Template.SharedUI.Pages.Weather;
using static System.Net.WebRequestMethods;

namespace Template.Client.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient http;
        public WeatherForecastService(HttpClient http)
        {
            this.http = http;
        }
        public Task<WeatherForecast[]?> GetWeatherForecastAsync()
        {
            return http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}

using System.Net.Http.Json;
using $ext_projectname$.Shared;
using $ext_projectname$.SharedUI.Pages.Weather;
using static System.Net.WebRequestMethods;

namespace $ext_projectname$.Client.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient http;

        //public WeatherForecastService(HttpClient http)
        //{
        //    this.http = http;
        //}

        public WeatherForecastService(HttpClient http) => this.http = http;

        //public Task<WeatherForecast[]?> GetWeatherForecastAsync()
        //{
        //    return http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        //}

        public Task<WeatherForecast[]?> GetWeatherForecastAsync() => http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
    }
}

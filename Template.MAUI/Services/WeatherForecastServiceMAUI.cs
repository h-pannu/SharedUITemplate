using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using $ext_projectname$.Shared;
using $ext_projectname$.SharedUI.Pages.Weather;

namespace $ext_projectname$.MAUI.Services
{
    public class WeatherForecastServiceMAUI : IWeatherForecastService
    {
        private readonly HttpClient http;

        //public WeatherForecastService(HttpClient http)
        //{
        //    this.http = http;
        //}

        public WeatherForecastServiceMAUI(HttpClient http) => this.http = http;

        //public Task<WeatherForecast[]?> GetWeatherForecastAsync()
        //{
        //    return http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        //}

        public Task<WeatherForecast[]> GetWeatherForecastAsync() => http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $ext_projectname$.Shared;

namespace $ext_projectname$.SharedUI.Pages.Weather
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]?> GetWeatherForecastAsync();
    }
}

using Microsoft.Extensions.Logging;
using Template.MAUI.Services;
using Template.SharedUI.Pages.Weather;

namespace Template.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://ckhp49fh-7025.usw3.devtunnels.ms/") });
            builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastServiceMAUI>();

            return builder.Build();
        }
    }
}
using MauiAppMobile.Data;
using Microsoft.Extensions.Logging;
using P06Shop.Shared.Configuration;
using P06Shop.Shared.Services.AuthService;
using P06Shop.Shared.Services.FilmService;
using MauiAppMobile;
using MauiAppMobile.Services.CustomAuthStateProvider;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using P06Shop.Shared.Services.SpeechService;

namespace MauiAppMobile {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            var configurationBuilder = new ConfigurationBuilder()
                        .AddJsonFile("wwwroot/appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"wwwroot/appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                        .Build();
            var appSettingsSection = configurationBuilder.GetSection(nameof(AppSettings));
            var appSettings = appSettingsSection.Get<AppSettings>();
            builder.Services.AddSingleton(appSettings);

            var uriBuilder = new UriBuilder(appSettings.BaseAPIUrl) {
                // Path = appSettingsSection.BaseAPIUrl,
            };

            builder.Services.AddHttpClient<IFilmService, FilmService>(client => client.BaseAddress = uriBuilder.Uri);
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            //builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddHttpClient<IAuthService, AuthService>(client => client.BaseAddress = uriBuilder.Uri);

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<ISpeechService>(_ => new SpeechService(appSettings.SpeechSettings));

            return builder.Build();
        }
    }
}

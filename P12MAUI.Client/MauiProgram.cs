using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.Http;
using P04WeatherForecastAPI.Client.ViewModels;
using P06Shop.Shared.Configuration;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.FilmService;
using P12MAUI.Client.MessageBox;
using P12MAUI.Client.ViewModels;
using System.Reflection;

namespace P12MAUI.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            ConfigureServices(builder);
            return builder.Build();
        }

        private static void ConfigureServices(MauiAppBuilder builder)
        {
            var appSettingsSection = ConfigureAppSettings(builder);
            var services = builder.Services;
            ConfigureAppServices(services, appSettingsSection);
            ConfigureViewModels(services);
            ConfigureViews(services);
            ConfigureHttpClients(services, appSettingsSection);
        }

        private static AppSettings ConfigureAppSettings(MauiAppBuilder builder)
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("P12MAUI.Client.appsettings.json");
            var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
            var appSettings = config.GetRequiredSection("AppSettings").Get<AppSettings>();

            builder.Services.AddSingleton(appSettings);


            return appSettings;
        }

        private static void ConfigureAppServices(IServiceCollection services, AppSettings appSettings)
        {
            //services.AddSingleton<IConnectivity>(Connectivity.Current);
            //services.AddSingleton<IGeolocation>(Geolocation.Default);
            //services.AddSingleton<IMap>(Map.Default);
            // konfiguracja serwisów 
            services.AddSingleton<IFilmService, FilmService>();
            services.AddSingleton<IMessageDialogService, MauiMessageDialogService>();
        }

        private static void ConfigureViewModels(IServiceCollection services)
        {
            // konfiguracja viewModeli 
            services.AddSingleton<FilmsViewModel>();
            services.AddTransient<FilmDetailsViewModel>();
        // services.AddSingleton<BaseViewModel,MainViewModelV3>();
        }

        private static void ConfigureViews(IServiceCollection services)
        {
            // konfiguracja okienek 
            services.AddSingleton<MainPage>();
            services.AddTransient<FilmDetailsView>();
        }

        private static void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
        {
            var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                //Path = appSettingsSection.BaseFilmEndpoint.Base_url,
            };
            //var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl) {
            // Path = appSettingsSection.BaseAPIUrl,
            //};
            //Microsoft.Extensions.Http
            services.AddHttpClient<IFilmService, FilmService>(client => client.BaseAddress = uriBuilder.Uri);
        }
    }
}
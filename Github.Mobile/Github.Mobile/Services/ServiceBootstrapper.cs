using Flurl.Http;
using Github.Mobile.Services.Api;
using Github.Mobile.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using Xamarin.Essentials;

namespace Github.Mobile.Services
{
    public static class ServiceBootstrapper
    {
        public static IServiceProvider Init()
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("Github.Mobile.appsettings.json");

            var host = new HostBuilder()
                        .ConfigureHostConfiguration(c =>
                        {
                            c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                        })
                        .ConfigureServices((c, x) =>
                        {
                            ConfigureServices(x);
                        })
                        .Build();

            return host.Services;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<App>();
            services.AddTransient<MainPage>();
            services.AddTransient<MainViewModel>();

            FlurlHttp.Configure(settings =>
            {
                settings.HttpClientFactory = new CustomHttpClientFactory();
            });

            services.AddScoped<IGithubUserApiClient, GithubUserApiClient>();
            services.AddScoped<IObjectMapperService, ObjectMapperService>();
            services.AddScoped<IGithubUserService, GithubUserService>();
        }

    }
}

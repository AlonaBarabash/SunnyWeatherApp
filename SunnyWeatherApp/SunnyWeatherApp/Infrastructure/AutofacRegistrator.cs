using Autofac;
using SunnyWeatherApp.Models.Location;
using SunnyWeatherApp.Repositories;
using SunnyWeatherApp.Repositories.AccuWeatherRepositories;
using SunnyWeatherApp.Repositories.AccuWeatherRepositories.Abstractions;
using SunnyWeatherApp.Services;
using SunnyWeatherApp.Services.Abstractions;
using SunnyWeatherApp.ViewModels;

namespace SunnyWeatherApp.Infrastructure
{
    public static class AutofacRegistrator
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<LocationWeatherListViewModel>().AsSelf();
            builder.RegisterType<SearchLocationListViewModel>().AsSelf();

            builder.RegisterType<LocationSearchService>().As<ILocationSearchService>();
            builder.RegisterType<WeatherService>().As<IWeatherService>();

            builder.RegisterType<LocationAccuWeatherRepository>().As<ILocationAccuWeatherRepository>();
            builder.RegisterType<WeatherAccuWeatherRepository>().As<IWeatherAccuWeatherRepository>();
            builder.RegisterType<LocationDataStoreRepository>().As<IDataStore<Location>>();
        }
    }
}

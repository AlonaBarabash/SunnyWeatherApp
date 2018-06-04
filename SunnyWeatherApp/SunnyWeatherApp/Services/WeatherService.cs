using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SunnyWeatherApp.Models;
using SunnyWeatherApp.Models.Weather;
using SunnyWeatherApp.Repositories.AccuWeatherRepositories.Abstractions;
using SunnyWeatherApp.Services.Abstractions;

namespace SunnyWeatherApp.Services
{
    class WeatherService : IWeatherService
    {
        private readonly IWeatherAccuWeatherRepository _weatherRepository;

        public WeatherService(IWeatherAccuWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<IList<Weather>> GetCurrentWeatherByLocationAsync(string locationKey)
        {
            return await _weatherRepository.GetWeatherByLocationAsync(locationKey);
        }
    }
}

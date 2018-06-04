using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyWeatherApp.Models.Weather;

namespace SunnyWeatherApp.Repositories.AccuWeatherRepositories.Abstractions
{
    public interface IWeatherAccuWeatherRepository
    {
        Task<IList<Weather>> GetWeatherByLocationAsync(string locationKey);
    }
}

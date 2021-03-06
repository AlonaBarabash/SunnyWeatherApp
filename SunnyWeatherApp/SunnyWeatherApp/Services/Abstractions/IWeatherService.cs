﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyWeatherApp.Models.Weather;

namespace SunnyWeatherApp.Services.Abstractions
{
    public interface IWeatherService
    {
        Task<IList<Weather>> GetCurrentWeatherByLocationAsync(string locationKey);
    }
}

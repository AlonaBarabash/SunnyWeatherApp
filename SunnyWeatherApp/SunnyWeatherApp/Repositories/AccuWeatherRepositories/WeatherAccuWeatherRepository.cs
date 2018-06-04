using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyWeatherApp.ApiRequestHelper;
using SunnyWeatherApp.Models.Weather;
using SunnyWeatherApp.Repositories.AccuWeatherRepositories;
using SunnyWeatherApp.Repositories.AccuWeatherRepositories.Abstractions;

namespace SunnyWeatherApp.Repositories.AccuWeatherRepositories
{
    public class WeatherAccuWeatherRepository : BaseAccuWeatherRepository, IWeatherAccuWeatherRepository
    {
        public Task<IList<Weather>> GetWeatherByLocationAsync(string locationKey)
        {
            return RequestBuilder.BuildGetRequest($"{BaseUrI}")
                .SetPathPart($"forecasts/v1/hourly/1hour/{locationKey}")
                .AddQueryStringParameter("apikey", $"{ApiKey}")
                .AddQueryStringParameter("details", "true")
                .AddQueryStringParameter("metric", "true")
                .GetAsync<IList<Weather>>();
        }
    }
}
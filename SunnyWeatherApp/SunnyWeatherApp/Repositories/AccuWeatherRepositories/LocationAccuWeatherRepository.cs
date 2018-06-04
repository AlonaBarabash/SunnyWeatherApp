using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyWeatherApp.ApiRequestHelper;
using SunnyWeatherApp.Models.Location;
using SunnyWeatherApp.Repositories.AccuWeatherRepositories;
using SunnyWeatherApp.Repositories.AccuWeatherRepositories.Abstractions;

namespace SunnyWeatherApp.Repositories.AccuWeatherRepositories
{
    public class LocationAccuWeatherRepository : BaseAccuWeatherRepository, ILocationAccuWeatherRepository
    {
        public Task<IList<Location>> GetLocationListByTextAsync(string searchText)
        {
            return RequestBuilder.BuildGetRequest($"{BaseUrI}")
                .SetPathPart($"locations/v1/search")
                .AddQueryStringParameter("apikey", $"{ApiKey}")
                .AddQueryStringParameter("q", $"{searchText}")
                .GetAsync<IList<Location>>();
        }
    }
}

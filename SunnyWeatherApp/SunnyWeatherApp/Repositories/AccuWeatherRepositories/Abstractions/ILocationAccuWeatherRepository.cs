using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyWeatherApp.Models.Location;

namespace SunnyWeatherApp.Repositories.AccuWeatherRepositories.Abstractions
{
    interface ILocationAccuWeatherRepository
    {
        Task<IList<Location>> GetLocationListByTextAsync(string searchText);
    }
}
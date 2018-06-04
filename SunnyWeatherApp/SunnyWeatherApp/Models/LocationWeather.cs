using System;

namespace SunnyWeatherApp.Models
{
    public class LocationWeather
    {
        public Location.Location Location { get; set; }
        public Weather.Weather CurrentWeather { get; set; }
    }
}
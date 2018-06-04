using System;

namespace SunnyWeatherApp.Models
{
    public class LocationWeather
    {
        public Location Location { get; set; }
        public Weather CurrentWeather { get; set; }
    }
}
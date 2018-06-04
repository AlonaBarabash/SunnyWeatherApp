using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyWeatherApp.Models.Weather
{
    public class Temperature
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }
}

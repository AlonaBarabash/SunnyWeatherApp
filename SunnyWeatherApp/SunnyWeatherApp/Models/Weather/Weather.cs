using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyWeatherApp.Models.Weather
{
    public class Weather
    {
        public DateTime DateTime { get; set; }
        public string IconPhrase { get; set; }
        public bool IsDaylight { get; set; }
        public Temperature Temperature { get; set; }
        public int RainProbability { get; set; }
        public int ShowProbability { get; set; }
        public int IceProbability { get; set; }
    }
}

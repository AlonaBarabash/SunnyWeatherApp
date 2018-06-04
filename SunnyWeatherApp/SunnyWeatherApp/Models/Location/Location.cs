using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyWeatherApp.Models.Location
{
    public class Location
    {
        public string Key { get; set; }
        public string LocalizedName { get; set; }
        public string Type { get; set; }
        public Country Country { get; set; }
        public AdministrativeArea AdministrativeArea { get; set; }
    }
}

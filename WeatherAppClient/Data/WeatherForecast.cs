﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAppClient.Data
{
    public class WeatherForecast : IShortWeatherForecast
    {
        public DateTime Date { get; set; }

        public double Wind { get; set; }

        public double TemperatureC { get; set; }

        public string Summary { get; set; }

        public string Icon { get; set; }

        public int Humidity { get; set; }

        public string Place { get; set; }

        public int Pressure { get; set; }

        public int Cloudiness { get; set; }
    }
}

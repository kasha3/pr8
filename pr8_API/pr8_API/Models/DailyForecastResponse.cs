using System;
using System.Collections.Generic;

namespace pr8_API.Models
{
    public class DailyForecastsResponse
    {
        public class DailyForecast
        {
            public DateTime Date { get; set; }
            public Sun Sun { get; set; }
            public Temperature Temperature { get; set; }
            public Temperature RealFeelTemperature { get; set; }
            public Forecast Day { get; set; }
            public Forecast Night { get; set; }
        }
        public class Sun
        {
            public DateTime Rise { get; set; }
            public DateTime Set { get; set; }
        }
        public List<DailyForecast> DailyForecasts { get; set; }
    }
}

using System;

namespace pr8_API.Models
{
    public class InHoursForecast
    {
        public DateTime DateTime { get; set; }
        public int WeatherIcon { get; set; }
        public string IconPhrase { get; set; }
        public TemperatureInfo Temperature { get; set; }
        public TemperatureInfo RealFeelTemp { get; set; }
        public Wind Wind { get; set; }
        public int RelativeHumidity { get; set; }
        public int UVIndex { get; set; }
        public string UVIndexText { get; set; }
    }
    public class TemperatureInfo
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }
}

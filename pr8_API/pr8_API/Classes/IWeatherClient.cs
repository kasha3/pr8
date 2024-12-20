using System;
using Refit;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pr8_API.Classes
{
    public interface IWeatherClient
    {
        [Get("/forecasts/v1/hourly/12hour/{locationKey}")]
        Task<IEnumerable<1HourForecast>> Get12Hour(
            string locationKey)
    }
}

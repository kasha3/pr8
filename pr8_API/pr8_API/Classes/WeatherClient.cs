using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace pr8_API.Classes
{
    public class WeatherClient
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly string _lang;
        private readonly HttpClient _client;

        public WeatherClient(string baseUrl, string apiKey, string lang)
        {
            _baseUrl = baseUrl;
            _apiKey = apiKey;
            _lang = lang;
            _client = new HttpClient { BaseAddress = new Uri(baseUrl)};
        }

        public async Task<IEnumerable<Location>> SearchLocationAsync(string query)
        {
            var response = await _client.GetAsync($"/locations/v1/cities/autocomplete?q={query}&language={_lang}&apikey={_apiKey}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Location>>(content);
        }

        public async Task<IEnumerable<InHoursForecast>> Get12HoursForecastAsync(string locationKey)
        {
            var response = await _client.GetAsync($"/forecasts/v1/hourly/12hour/{locationKey}?language={_lang}&details=true&apikey={_apiKey}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<InHoursForecast>>(content);
        }

        public async Task<IEnumerable<DailyForecast>> Get5DaysForecastsAsync(string locationKey)
        {
            var response = await _client.GetAsync($"/forecasts/v1/daily/5day/{locationKey}?language={_lang}&details=true&apikey={_apiKey}&metric=true");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<DailyForecast>>(content);
        }
    }
}

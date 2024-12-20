using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using pr8_API.Classes;
using Refit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pr8_API
{
    public class WeatherService
    {
        private readonly Classes.WeatherClient _client;
        private readonly Classes.AppDbContext _context;
        private const string _baseURL = "http://dataservice.accuweather.com";
        private const string _apiKey = "3QRmEXxOJvOecVi7pTn9BADKNwhcEbHl";
        private const string _language = "ru-RU";

        public WeatherService()
        {
            _client = new Classes.WeatherClient(_baseURL, _apiKey, _language);
            _context = new Classes.AppDbContext();
        }
        public async Task<IEnumerable<Location>> SearchLocationAsync(string query)
        {
            var cachekey = $"search-location-{query.ToLower()}";
            var cachedData = await GetCacheOrDefault<IEnumerable<Location>>(cachekey);
            if (cachedData != null) return cachedData;
            var location = await _client.SearchLocationAsync(query);
            await SaveCache(cacheKey, location);
            return location;
        }
        public async Task<IEnumerable<InHoursForecast>> Get12HoursForecastAsync(string locationKey)
        {
            var cacheKey = $"12-hours-forecast-{locationKey}";

            var cachedData = await GetCacheOrDefault<IEnumerable<InHoursForecast>>(cacheKey);
            if (cachedData != null)
            {
                cachedData = cachedData.Where(f => f.DateTime >= DateTime.Now);
                if (cachedData.Count() == 12)
                {
                    return cachedData;
                }
            }
            try
            {
                var result = await _client.Get12HoursForecastAsync(locationKey);
                await SaveCache(cacheKey, result);
                return result;
            }
            catch (ApiException)
            {
                return cachedData;
            }
        }
        public async Task<DailyForecast> Get5DaysForecastAsync(string locationKey)
        {
            var cacheKey = $"5-days-forecast-{locationKey}";

            var cachedData = await GetCacheOrDefault<DailyForecast>(cacheKey);

            if (cachedData != null)
            {
                cachedData.DailyForecasts = cachedData.DailyForecasts.Where(f => f.Date >= DateTime.Now).ToList();

                if (cachedData.DailyForecasts.Count() == 5)
                {
                    return cachedData;
                }
            }
            try
            {
                var result = await _client.Get5DaysForecastsAsync(locationKey);
                await SaveCache(cacheKey, result);
                return result;
            }
            catch (ApiException)
            {
                return cachedData;
            }
        }
        private async Task<T> GetCacheOrDefault<T>(string cacheKey)
        {
            var cache = await _context.WeatherCache.FirstOrDefaultAsync(c => c.CacheKey == cacheKey);

            if (cache != null)
            {
                return JsonConvert.DeserializeObject<T>(cache.JsonData);
            }

            return default;
        }
        private async Task SaveCache<T>(string cacheKey, T data)
        {
            var existCache = await _context.WeatherCache.FirstOrDefaultAsync(c => c.CacheKey == cacheKey);
            if (existCache != null) existCache.JsonData = JsonConvert.SerializeObject(data);
            else
            {
                var weatherCache = new WeatherCache { CacheKey = cacheKey, JsonData = JsonConvert.SerializeObject(data) };
                await _context.AddAsync(weatherCache);
            }
            await _context.SaveChangesAsync();
        }
    }
}

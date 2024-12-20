using System;

namespace pr8_API
{
    public class WeatherService
    {
        private readonly IWeatherClient _client;
        private readonly AppDbContext _context;
        private const string _baseURL = "http://dataservice.accuweather.com";
        private const string _apiKey = "3QRmEXxOJvOecVi7pTn9BADKNwhcEbHl";
        private const string _language = "ru-RU";

        public WeatherService()
        {
            _client = RestService.For<IWeatherClient>(_baseURL);
            _context = new AppDbContext();
        }
    }
}

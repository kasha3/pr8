using System;

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
            _client = RestService.For<Classes.WeatherClient>(_baseURL);
            _context = new Classes.AppDbContext();
        }
    }
}

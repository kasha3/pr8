using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr8_WPF_Weather.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();

            _weatherService = new WeatherService();
            string sity = "Пермь";
            LoadDailyForecasts(sity);
        }

        public async void LoadDailyForecasts(string sity)
        {
            try
            {
                var searchResult = await _weatherService.SearchLocationsAsync(sity);

                var location = searchResult.First();

                var hoursForecast = await _weatherService.Get12HoursForecastAsync(location.Key);

                //сейчас
                var currentWeather = hoursForecast.First();
                lb_temp_now.Content = $"{currentWeather.Temperature.Value.ToString()}°";
                img_now.Source = WeatherImageProvider.GetImage(currentWeather.WeatherIcon);
                lb_condition_now.Content = currentWeather.IconPhrase;
                lb_temp_feel_now.Content = $"{currentWeather.RealFeelTemperature.Value.ToString()}°";
                lb_wind.Content = $"{currentWeather.Wind.Speed.Value.ToString()}м/с";
                lb_humidity.Content = $"{currentWeather.RelativeHumidity.ToString()}%";
                lb_uv.Content = $"{currentWeather.UVIndex}, {currentWeather.UVIndexText}";

                //по часам
                parent1.Children.Clear();
                foreach (var forecast in hoursForecast)
                {
                    parent1.Children.Add(new Element.itm_HourlyWeather(forecast));
                }

                //по дням
                var dailyForecasts = await _weatherService.Get5DaysForecastAsync(location.Key);

                parent.Children.Clear();
                foreach (var forecast in dailyForecasts.DailyForecasts)
                {
                    parent.Children.Add(new Element.itm_Weather(forecast));
                }
            }
            catch
            {
                MessageBox.Show("Город не найден или введен некорректно. Пожалуйста, проверьте ввод.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void KeyDown_Search(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string search_sity = tb_search.Text.Trim();
                if (string.IsNullOrEmpty(search_sity))
                {
                    LoadDailyForecasts("Пермь");
                }
                else
                {
                    LoadDailyForecasts(search_sity);
                }
            }
        }
    }
}

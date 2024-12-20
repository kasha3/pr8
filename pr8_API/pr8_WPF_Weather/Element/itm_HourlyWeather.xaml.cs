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
using pr8_API.Models;

namespace pr8_WPF_Weather.Element
{
    /// <summary>
    /// Логика взаимодействия для itm_HourlyWeather.xaml
    /// </summary>
    public partial class itm_HourlyWeather : UserControl
    {
        public itm_HourlyWeather(InHoursForecast forecast)
        {
            InitializeComponent();
            lb_time.Content = forecast.DateTime.ToString("HH:mm");
            img_pogoda.Source = WeatherImageProvider.GetImage(forecast.WeatherIcon);
            lb_temp.Content = $"{forecast.Temperature.Value}°";
            lb_humidity.Content = $"{forecast.RelativeHumidity.ToString()}%";
        }
    }
}

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
    /// Логика взаимодействия для itm_Weather.xaml
    /// </summary>
    public partial class itm_Weather : UserControl
    {
        public itm_Weather(DailyForecastsResponse.DailyForecast forecast)
        {
            InitializeComponent();
            lb_day.Content = forecast.Date.Day.ToString();
            lb_month.Content = forecast.Date.ToString("MMMM");
            lb_week.Content = forecast.Date.ToString("dddd");

            //день
            lb_temp_day.Content = $"{forecast.Day.WetBulbTemperature.Maximum.Value.ToString()}°";
            img_day.Source = WeatherImageProvider.GetImage(forecast.Day.Icon);
            lb_condition_day.Content = forecast.Day.IconPhrase;
            lb_humidity_day.Content = $"{forecast.Day.RelativeHumidity.Average}%";
            lb_wind_day.Content = forecast.Day.Wind.Speed.Value.ToString();
            lb_wind_direction_day.Content = forecast.Day.Wind.Direction.Localized;
            lb_temp_feel_day.Content = forecast.RealFeelTemperature.Maximum.Value.ToString();

            //ночь
            lb_temp_night.Content = $"{forecast.Night.WetBulbTemperature.Maximum.Value.ToString()}°";
            img_night.Source = WeatherImageProvider.GetImage(forecast.Night.Icon);
            lb_condition_night.Content = forecast.Night.IconPhrase;
            lb_humidity_night.Content = $"{forecast.Night.RelativeHumidity.Average}%";
            lb_wind_night.Content = forecast.Night.Wind.Speed.Value.ToString();
            lb_wind_direction_night.Content = forecast.Night.Wind.Direction.Localized;
            lb_temp_feel_night.Content = forecast.RealFeelTemperature.Minimum.Value.ToString();

            //солнце
            lb_rise.Content = forecast.Sun.Rise.ToString("HH:mm");
            lb_set.Content = forecast.Sun.Set.ToString("HH:mm");
        }
    }
}

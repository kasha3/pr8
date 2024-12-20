using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace pr8_WPF_Weather
{
    public class WeatherImageProvider
    {
        public static BitmapImage GetImage(int imageId)
        {
            return new BitmapImage(new Uri($"pack://application:,,,/Images/{imageId}.png"));
        }
    }
}

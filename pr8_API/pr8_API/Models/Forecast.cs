namespace pr8_API.Models
{
    public class Forecast
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public string ShortPhrase { get; set; }
        public string LongPhrase { get; set; }
        public Wind Wind { get; set; }
        public RelativeHumidity RelativeHumidity { get; set; }
        public Temperature WetBulbTemperature { get; set; }
    }
    public class RelativeHumidity
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Average { get; set; }
    }
}

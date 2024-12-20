namespace pr8_API.Models
{
    public class Wind
    {
        public WindSpeed Speed { get; set; }
        public WindDirection Direction { get; set; }
    }
    public class WindSpeed
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }
    public class WindDirection
    {
        public int Degrees { get; set; }
        public string Localized { get; set; }
        public string English { get; set; }
    }
}

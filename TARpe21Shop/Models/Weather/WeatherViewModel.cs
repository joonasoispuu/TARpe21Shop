namespace Tarpe21Shop.Models.Weather
{
    public class WeatherViewModel
    {
        public List<ForecastEntry> ForecastEntries { get; set; } = new List<ForecastEntry>();
    }

    public class ForecastEntry
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string Icon { get; set; }
    }
}

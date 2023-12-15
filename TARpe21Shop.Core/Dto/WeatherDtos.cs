namespace Tarpe21Shop.Core.Dto.WeatherDtos
{
    public class OpenWeatherMapForecastDto
    {
        public List<ForecastDto> List { get; set; }
        public CityDto City { get; set; }
    }

    public class ForecastDto
    {
        public MainDto Main { get; set; }
        public List<WeatherDto> Weather { get; set; }
        public CloudsDto Clouds { get; set; }
        public WindDto Wind { get; set; }
        public string DtTxt { get; set; }
        public SysDto Sys { get; set; }
        public double Pop { get; set; }
        public RainDto Rain { get; set; }
        public SnowDto Snow { get; set; }
        public long Dt { get; set; }
    }

    public class MainDto
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
        public int Humidity { get; set; }
        public double TempKf { get; set; }
    }

    public class WeatherDto
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class CloudsDto
    {
        public int All { get; set; }
    }

    public class WindDto
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }

    public class SysDto
    {
        public string Pod { get; set; }
    }

    public class RainDto
    {
        public double? ThreeHours { get; set; }
    }

    public class SnowDto
    {
        public double? ThreeHours { get; set; }
    }

    public class CityDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CoordDto Coord { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public int Timezone { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }

    public class CoordDto
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class WeatherResultDto
    {
        public List<WeatherEntryDto> ForecastEntries { get; set; } = new List<WeatherEntryDto>();
    }

    public class WeatherEntryDto
    {
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Date { get; set; }
    }
}

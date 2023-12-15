using System.Net;
using Newtonsoft.Json;
using Tarpe21Shop.Core.Dto.WeatherDtos;
using Tarpe21Shop.Core.ServiceInterface;

namespace TARpe21Shop.ApplicationServices.Services
{
    public class WeatherForecastsServices : IWeatherForecastsServices
    {
        private const string ApiKey = "a30976354409962afac710433931cbf7";

        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            var url = $"http://api.openweathermap.org/data/2.5/forecast?q=Tallinn&appid={ApiKey}&units=metric";

            using (WebClient client = new WebClient())
            {
                string json = await client.DownloadStringTaskAsync(url);
                var forecastData = JsonConvert.DeserializeObject<OpenWeatherMapForecastDto>(json);

                foreach (var forecastDto in forecastData.List)
                {
                    var weatherEntry = new WeatherEntryDto
                    {
                        Temperature = forecastDto.Main.Temp,
                        FeelsLike = forecastDto.Main.FeelsLike,
                        TempMin = forecastDto.Main.TempMin,
                        TempMax = forecastDto.Main.TempMax,
                        Humidity = forecastDto.Main.Humidity,
                        WindSpeed = forecastDto.Wind.Speed,
                        Description = forecastDto.Weather[0].Description,
                        Icon = forecastDto.Weather[0].Icon,
                        Date = DateTimeOffset.FromUnixTimeSeconds(forecastDto.Dt).DateTime.ToString("yyyy-MM-dd HH:mm:ss")
                    };

                    dto.ForecastEntries.Add(weatherEntry);
                }
            }

            return dto;
        }
    }
}

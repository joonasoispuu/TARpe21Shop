using Tarpe21Shop.Core.Dto.WeatherDtos;

namespace Tarpe21Shop.Core.ServiceInterface
{
    public interface IWeatherForecastsServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}
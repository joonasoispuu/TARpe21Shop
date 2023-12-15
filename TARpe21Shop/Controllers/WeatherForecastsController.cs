using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tarpe21Shop.Core.Dto.WeatherDtos;
using Tarpe21Shop.Core.ServiceInterface;
using Tarpe21Shop.Models.Weather;

namespace Tarpe21Shop.Controllers
{
    public class WeatherForecastsController : Controller
    {
        private readonly IWeatherForecastsServices _weatherForecastServices;

        public WeatherForecastsController(IWeatherForecastsServices weatherForecastServices)
        {
            _weatherForecastServices = weatherForecastServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShowWeather()
        {
            var dto = new WeatherResultDto();
            await _weatherForecastServices.WeatherDetail(dto);
            var vm = new WeatherViewModel();

            foreach (var entry in dto.ForecastEntries)
            {
                vm.ForecastEntries.Add(new ForecastEntry
                {
                    Date = entry.Date,
                    Description = entry.Description,
                    Temperature = entry.Temperature,
                    FeelsLike = entry.FeelsLike,
                    TempMin = entry.TempMin,
                    TempMax = entry.TempMax,
                    Humidity = entry.Humidity,
                    WindSpeed = entry.WindSpeed,
                    Icon = entry.Icon
                });
            }

            return View("City", vm);
        }

        [HttpGet]
        public IActionResult City()
        {
            return RedirectToAction("Index");
        }
    }
}

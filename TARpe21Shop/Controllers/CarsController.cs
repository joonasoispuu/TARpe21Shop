using Microsoft.AspNetCore.Mvc;
using TARpe21Shop.ApplicationServices.Services;
using TARpe21Shop.Core.Dto;
using TARpe21Shop.Data;
using TARpe21Shop.Core.Dto.ServiceInterface;
using TARpe21Shop.Models.Cars;

namespace Tarpe21Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly TARpe21ShopContext _context;
        private readonly IFilesServices _filesServices;

        public CarsController(ICarService carService, TARpe21ShopContext context, IFilesServices filesServices)
        {
            _carService = carService;
            _context = context;
            _filesServices = filesServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new CarDto
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    Year = x.Year,
                    Mileage = x.Mileage,
                    Price = x.Price,
                    Color = x.Color,
                    IsUsed = x.IsUsed,
                    CreatedAt = x.CreatedAt,
                    ModifiedAt = x.ModifiedAt
                });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel vm = new();
            return View("Create", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = Guid.NewGuid(),
                Brand = vm.Brand,
                Model = vm.Model,
                Year = vm.Year,
                Mileage = vm.Mileage,
                Price = vm.Price,
                Color = vm.Color,
                IsUsed = vm.IsUsed,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            await _carService.CreateCarAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
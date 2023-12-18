using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe21Shop.ApplicationServices.Services;
using TARpe21Shop.Core.Domain;
using TARpe21Shop.Core.Dto;
using TARpe21Shop.Core.ServiceInterface;
using TARpe21Shop.Data;
using TARpe21Shop.Models.Car;
using TARpe21Shop.Models.Cars;

namespace TARpe21Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARpe21ShopContext _context;
        private readonly ICarService _carsServices;
        private readonly IFilesServicesCar _filesServicesCar;

        public CarsController(
            TARpe21ShopContext context,
            ICarService carsServices,
            IFilesServicesCar filesServicesCar)
        {
            _context = context;
            _carsServices = carsServices;
            _filesServicesCar = filesServicesCar;
        }

        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderBy(x => x.CreatedAt)
                .Select(x => new CarIndexViewModel
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
            return View("CreateUpdate", new CarCreateUpdateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var carImages = vm.Image.Select(x => new FileToDatabaseCar
            {
                Id = x.ImageId,
                ImageData = x.ImageData,
                ImageTitle = x.ImageTitle,
                CarId = x.CarId
            }).ToList();

            var carDto = new CarDto
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Model = vm.Model,
                Year = vm.Year,
                Mileage = vm.Mileage,
                Price = vm.Price,
                Color = vm.Color,
                IsUsed = vm.IsUsed,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = carImages
            };

            var result = await _carsServices.Create(carDto);
            return result != null ? RedirectToAction(nameof(Index)) : View("CreateUpdate", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carsServices.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var photos = await _context.FilesToDatabaseCar
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new CarCreateUpdateViewModel
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Mileage = car.Mileage,
                Price = car.Price,
                Color = car.Color,
                IsUsed = car.IsUsed,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt,
                Image = photos.ToList()
            };

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var carImages = vm.Image.Select(x => new FileToDatabaseCar
            {
                Id = x.ImageId,
                ImageData = x.ImageData,
                ImageTitle = x.ImageTitle,
                CarId = x.CarId
            }).ToList();

            var carDto = new CarDto
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Model = vm.Model,
                Year = vm.Year,
                Mileage = vm.Mileage,
                Price = vm.Price,
                Color = vm.Color,
                IsUsed = vm.IsUsed,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = carImages
            };

            var result = await _carsServices.Update(carDto);
            return result != null ? RedirectToAction(nameof(Index)) : View("CreateUpdate", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carsServices.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var photos = await _context.FilesToDatabaseCar
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new CarDetailsViewModel
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Mileage = car.Mileage,
                Price = car.Price,
                Color = car.Color,
                IsUsed = car.IsUsed,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt,
                Image = photos.ToList()
            };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var photos = await _context.FilesToDatabaseCar
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new CarDeleteViewModel
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Mileage = car.Mileage,
                Price = car.Price,
                Color = car.Color,
                IsUsed = car.IsUsed,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt,
                Image = photos.ToList()
            };
            return View(vm);
        }
    }
}

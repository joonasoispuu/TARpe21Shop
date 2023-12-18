using Microsoft.EntityFrameworkCore;
using TARpe21Shop.Core.Domain;
using TARpe21Shop.Core.Dto;
using TARpe21Shop.Core.ServiceInterface;
using TARpe21Shop.Data;

namespace TARpe21Shop.ApplicationServices.Services
{
    public class CarsServices : ICarService
    {
        private readonly TARpe21ShopContext _context;
        private readonly IFilesServicesCar _files;

        public CarsServices(TARpe21ShopContext context, IFilesServicesCar files)
        {
            _context = context;
            _files = files;
        }

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car
            {
                Id = Guid.NewGuid(),
                Brand = dto.Brand,
                Model = dto.Model,
                Year = dto.Year,
                Mileage = dto.Mileage,
                Price = dto.Price,
                Color = dto.Color,
                IsUsed = dto.IsUsed,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, car);
            }

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> Update(CarDto dto)
        {
            var car = new Car
            {
                Id = dto.Id,
                Brand = dto.Brand,
                Model = dto.Model,
                Year = dto.Year,
                Mileage = dto.Mileage,
                Price = dto.Price,
                Color = dto.Color,
                IsUsed = dto.IsUsed,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now
            };

            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, car);
            }

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Car> Delete(Guid id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FilesToDatabaseCar
                .Where(x => x.CarId == id)
                .Select(y => new FileToDatabaseDtoCars
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    CarId = y.CarId
                })
                .ToArrayAsync();

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }

    }
}

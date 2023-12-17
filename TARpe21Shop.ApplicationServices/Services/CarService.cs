using Microsoft.EntityFrameworkCore;
using TARpe21Shop.Core.Domain;
using TARpe21Shop.Core.Dto;
using TARpe21Shop.Core.Dto.ServiceInterface;
using TARpe21Shop.Data;

public class CarService : ICarService
{
    private readonly TARpe21ShopContext _context;

    public CarService(TARpe21ShopContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CarDto>> GetAllCarsAsync()
    {
        return await _context.Cars.Select(car => new CarDto
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
            ModifiedAt = car.ModifiedAt
        }).ToListAsync();
    }

    public async Task<CarDto> GetCarByIdAsync(Guid id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null) return null;

        return new CarDto
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
            ModifiedAt = car.ModifiedAt
        };
    }

    public async Task<CarDto> CreateCarAsync(CarDto carDto)
    {
        var car = new Car
        {
            Brand = carDto.Brand,
            Model = carDto.Model,
            Year = carDto.Year,
            Mileage = carDto.Mileage,
            Price = carDto.Price,
            Color = carDto.Color,
            IsUsed = carDto.IsUsed,
            CreatedAt = DateTime.Now,
            ModifiedAt = DateTime.Now
        };

        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();

        carDto.Id = car.Id;
        return carDto;
    }

    public async Task UpdateCarAsync(Guid id, CarDto carDto)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null) return;

        car.Brand = carDto.Brand;
        car.Model = carDto.Model;
        car.Year = carDto.Year;
        car.Mileage = carDto.Mileage;
        car.Price = carDto.Price;
        car.Color = carDto.Color;
        car.IsUsed = carDto.IsUsed;
        car.ModifiedAt = DateTime.Now;

        _context.Cars.Update(car);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCarAsync(Guid id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null) return;

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
    }
}

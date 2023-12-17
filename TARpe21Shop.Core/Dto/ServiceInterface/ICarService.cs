namespace TARpe21Shop.Core.Dto.ServiceInterface
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllCarsAsync();
        Task<CarDto> GetCarByIdAsync(Guid id);
        Task<CarDto> CreateCarAsync(CarDto carDto);
        Task UpdateCarAsync(Guid id, CarDto carDto);
        Task DeleteCarAsync(Guid id);
    }
}

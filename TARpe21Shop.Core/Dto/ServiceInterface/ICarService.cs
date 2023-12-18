using System;
using System.Threading.Tasks;
using TARpe21Shop.Core.Domain;
using TARpe21Shop.Core.Dto;

namespace TARpe21Shop.Core.ServiceInterface
{
    public interface ICarService
    {
        Task<Car> Create(CarDto dto);
        Task<Car> Update(CarDto dto);
        Task<Car> GetAsync(Guid id);
    }
}

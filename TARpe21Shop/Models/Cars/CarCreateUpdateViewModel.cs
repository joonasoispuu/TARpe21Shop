using TARpe21Shop.Core.Dto;

namespace TARpe21Shop.Models.Cars
{
    public class CarCreateUpdateViewModel
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public bool IsUsed { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToApiCarsDto> FileToApiCarsDto { get; set; } = new List<FileToApiCarsDto>();
    }
}

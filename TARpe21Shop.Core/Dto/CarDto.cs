using Microsoft.AspNetCore.Http;

namespace TARpe21Shop.Core.Dto
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public bool IsUsed { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToApiCarsDto> FileToApiCarsDto { get; set; } = new List<FileToApiCarsDto>();
    }
}

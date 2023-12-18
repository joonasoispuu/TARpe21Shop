using TARpe21Shop.Models.Cars;
using TARpe21Shop.Models.RealEstate;

namespace TARpe21Shop.Models.Car
{
    public class CarDeleteViewModel
    {
        public Guid? Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public bool IsUsed { get; set; }
        public List<ImageViewModel> Image { get; set; } = new List<ImageViewModel>();
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

using System;

namespace TARpe21Shop.Core.Domain
{
    public class FileToDatabaseCar
    {
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? CarId { get; set; }
    }
}

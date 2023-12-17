namespace TARpe21Shop.Core.Domain
{
    public class FileToApiCars
    {
        public Guid Id { get; set; }
        public string ExistingFilePath { get; set; }
        public Guid? CarsId { get; set; }
    }
}
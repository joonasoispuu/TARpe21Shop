namespace TARpe21Shop.Core.Dto
{
    public class FileToApiCarsDto
    {
        public Guid Id { get; set; }
        public string ExistingFilePath { get; set; }
        public Guid? CarsId { get; set; }
    }
}